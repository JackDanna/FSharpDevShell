
{
  description = "A FSharp Dev Shell";

  outputs = { self, nixpkgs }:
  let
    system = "x86_64-linux";
    pkgs = import nixpkgs {
      inherit system;
      config = {
        allowUnfreePredicate = pkg: builtins.elem (pkgs.lib.getName pkg) [
          "vscode-with-extensions"
          "vscode"
          "vscode-extension-mhutchie-git-graph"
        ];
      };
    };
  in 
  {
    packages.${system} = {
      default = pkgs.writeShellScriptBin "run" ''
        nix develop -c -- code .
      '';
    };

    devShells.${system}.default = pkgs.mkShell rec {
      name = "FSharpDevShell";
      buildInputs = with pkgs; [
        bashInteractive
        dotnet-sdk_9
        (vscode-with-extensions.override  {
          vscode = pkgs.vscode;
          vscodeExtensions = with pkgs.vscode-extensions; [
            # ionide.ionide-fsharp
            ms-dotnettools.csharp
            jnoortheen.nix-ide
            mhutchie.git-graph
          ] ++ pkgs.vscode-utils.extensionsFromVscodeMarketplace [
            {
              name = "ionide-fsharp";
              publisher = "ionide";
              version = "7.25.6";
              sha256 = "sha256-dpybk2UoE2d7mLTzmmrLqKmKOfSihzSL4sN3KprHkYo=";
            }
            {
              name = "vscode-dotnet-runtime";
              publisher = "ms-dotnettools";
              version = "2.2.8";
              sha256 = "sha256-1dwkkaGQC5CZjOmebzSSqkomhA0hOXiIv8jV+Vo8jcw=";
            }
            {
              name = "vscode-dotnet-pack";
              publisher = "ms-dotnettools";
              version = "1.0.13";
              sha256 = "sha256-z3xiXgWADSHdZM/+MSmqRXqDjiX4O6whevN1zSmByWQ=";
            }
          ];
        })
      ];

      shellHook = ''
        export PS1+="${name}> "
        echo "Welcome to the FSharp Dev Shell!"
      '';
    };
  }; 

}

