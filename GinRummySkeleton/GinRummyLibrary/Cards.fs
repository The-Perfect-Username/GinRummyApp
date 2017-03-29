module Cards

type Suit = Spades | Clubs | Hearts | Diamonds
type Rank = Ace | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King
type Card = { suit: Suit; rank: Rank}

type Hand = Card seq
type Deck = Card seq

let AllSuits = [ Spades; Clubs; Hearts; Diamonds ]
let AllRanks = [ Ace; Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King ]

let allCards = 
    seq { 
        for s in AllSuits do
            for r in AllRanks do
                yield {suit=s; rank=r}
    }

let FullDeck = 
    allCards

// Create new random object
let rand = new System.Random()

// Swap two elements in an array
let swap (a: _[]) x y =
    let tmp = a.[x]
    a.[x] <- a.[y]
    a.[y] <- tmp

let Shuffle (deck:Deck) = 
    // Temporarily convert sequence to an array
    let deckArray = Seq.toArray deck
    // Iterate through the array and swap the current indexed element with a random indexed element
    Array.iteri (fun x _ -> swap deckArray x (rand.Next(x, Array.length deckArray))) deckArray
       // Covnert back to sequence and return shuffled deck
    Array.toSeq deckArray

// Add other functions here related to Card Games ...