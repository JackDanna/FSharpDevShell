// https://www.geeksforgeeks.org/count-number-ways-reach-given-score-game/

// let rec findValidNumCombosRecursively scoreToReach (index: int) (scorablePointsPerRound: int list) =
    
//     if scoreToReach = 0 then 1u
//     elif scoreToReach < 0 then 0u
//     elif index >= (scorablePointsPerRound.Length) then 0u
//     else
//         let currentIndexResult = findValidNumCombosRecursively (scoreToReach - scorablePointsPerRound[index]) index scorablePointsPerRound
//         let nextIndexResult = findValidNumCombosRecursively scoreToReach (index + 1) scorablePointsPerRound
//         currentIndexResult + nextIndexResult
    

// let result = findValidNumCombosRecursively 20 0 [3;5;10]

// result
// |> string
// |> printfn "%s"

// let rec temp scoreToReach currentScore (index: int) (possiblePointsThatCanBeScoredList: int list) : uint =
//     if currentScore = scoreToReach then 1u
//     elif currentScore > scoreToReach then 0u
//     elif index >= possiblePointsThatCanBeScoredList.Length then 0u
//     else
//         let currentIndexResult = temp scoreToReach (currentScore + possiblePointsThatCanBeScoredList[index]) index possiblePointsThatCanBeScoredList

//         let nextIndexResult = temp scoreToReach currentScore (index + 1) possiblePointsThatCanBeScoredList
        
//         currentIndexResult + nextIndexResult

// let result = temp 13 0 0 [3;5;10]

// result
// |> string
// |> printfn "%s"


// // https://www.geeksforgeeks.org/score-of-two-players-after-the-alternative-round-of-game/#
// let rec isEven num =
//     let remainder = num % 2

//     if remainder = 0 then true
//     elif remainder = 1 then false
//     else isEven (num / 2)

// let rec temp (nums: int list) pOneScore pTwoScore isPlayerOneTurn : int * int =
//     if nums.Length = 0 then
//         (pOneScore, pTwoScore)
//     else

//         let newNums = if isEven nums.Head then List.rev nums.Tail else nums.Tail

//         if isPlayerOneTurn then
//             temp newNums (pOneScore + nums.Head) pTwoScore (not isPlayerOneTurn)
//         else 
//             temp newNums pOneScore (pTwoScore + nums.Head) (not isPlayerOneTurn)

// let result = temp [4;3;1;2] 0 0 true

// result
// |> string
// |> printfn "%s"

// https://claude.ai/chat/069e06b4-4255-4b82-bb82-6f36865e1a58
// let stringScoreToPoints =
//     function
//     | "NORMAL" -> 100
//     | "SUPER" -> 200
//     | "MEGA" -> 500
//     | _ -> 0

// let calculatePoints currentScore lastMovesAmount lastMove =
//     currentScore + ((max 1 >> min 4) lastMovesAmount * stringScoreToPoints lastMove)

// let rec temp (moves: string list) lastMove currentScore lastMovesAmount =
    
    // match moves with
    // | [] -> calculatePoints currentScore lastMovesAmount lastMove
    // | currentMove :: (y :: movesTail)@tail ->
    //     let tempTemp = temp movesTail currentMove
    //     if lastMove = currentMove then
    //         tempTemp currentScore (lastMovesAmount + 1)
    //     else
    //         tempTemp (calculatePoints currentScore lastMovesAmount lastMove) 1

// let result = temp ["NORMAL"; "NORMAL"; "SUPER"; "SUPER"; "SUPER"; "MEGA"] "" 0 0

// result
// |> string
// |> printfn "%s"
