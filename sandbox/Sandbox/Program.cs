using System;using System;
using System.Timers;

class Program
{
     int height = 30;
  int width = 30;
  int h = 0;
  

  static void Main(string[] args)
    {
 
  bool running  = true;

 while (running)
 {

    while (h < height){
Console.WriteLine("eat");
    }
    
 }
  

    }
}

    
//     static List<string> gamepieces = new List<string>();

//       static string a1 = " ";
//        static string a2 = " ";
//         static string a3 = " ";
//        static string b1 = " ";
//        static string b2 = " ";
//          static string b3 = " ";
//        static string c1 = " ";
//        static string c2 = " ";
//        static string c3 = " ";
//        static bool running = true;

       
//     static void Main(string[] args)
//     {
//         gamepieces.Add(a1);
//         gamepieces.Add(a2);
//         gamepieces.Add(a3);
//         gamepieces.Add(b1);
//         gamepieces.Add(b2);
//         gamepieces.Add(b3);
//         gamepieces.Add(c1);
//         gamepieces.Add(c2);
//         gamepieces.Add(c3);
        

//         while(running){
//             Console.Clear();
//             drawGameBoard();
//             string player = "X";
//             Console.Write($"{player}: What postiton: ");
//             placePiece(player);
//             Console.Clear();
//             drawGameBoard();
            
//             if(CheckForWin(player)){
//                 Console.WriteLine($"{player} Won!!");
//                 break;
//             }
//             player = "O";
//             Console.Write($"{player}: What postiton: ");
//             placePiece(player);
//             if(CheckForWin(player)){
//                 Console.WriteLine($"{player} Won!!");
//                 break;
//             }
            

//         };
    
        
//     }

//   static void drawGameBoard(){
       
//         Console.WriteLine($"    1 2 3");
//         Console.WriteLine($"A   {a1}|{a2}|{a3}");
//         Console.WriteLine($"    -+-+-");
//         Console.WriteLine($"B   {b1}|{b2}|{b3}");
//         Console.WriteLine($"    -+-+-");
//         Console.WriteLine($"C   {c1}|{c2}|{c3}");
//     }


//     static void placePiece(string player){
//         bool selection = true;
//         while (selection){
//         string innput = Console.ReadLine();

//         if(checkplace(innput, gamepieces)){
       
        
//             if (innput == "A1"){
//                 a1 = player;
//                 selection = false;
//             }
//             else if (innput == "A2"){
//                 a2 = player;
//                 selection = false;
//             }
//             else if (innput == "A3"){
//                 a3 = player;
//                 selection = false;
//             }

//             else if (innput == "B1"){
//                 b1 = player;
//                 selection = false;
//             }
//             else if (innput == "B2"){
//                 b2 = player;
//                 selection = false;
//             }
//             else if (innput == "B3"){
//                 b3 = player;
//                 selection = false;
//             }

//             else if (innput == "C1"){
//                 c1 = player;
//                 selection = false;
//             }
//             else if (innput == "C2"){
//                 c2 = player;
//                 selection = false;
//             }
//             else if (innput == "C3"){
//                 c3 = player;
//                 selection = false;
//             }
//             else{
//                 Console.WriteLine("Please Choose Valid Position: ");

//             }
            
        
            
        
//         }
//              else{
//                 Console.WriteLine("Please Choose Valid Position: ");

//             }

            

//     }

//      static bool CheckForWin(string player)
//     {
//         // Check rows
//         if ((a1 == player && a2 == player && a3 == player) ||
//             (b1 == player && b2 == player && b3 == player) ||
//             (c1 == player && c2 == player && c3 == player))
//         {
//             return true;
//         }

//         // Check columns
//         if ((a1 == player && b1 == player && c1 == player) ||
//             (a2 == player && b2 == player && c2 == player) ||
//             (a3 == player && b3 == player && c3 == player))
//         {
//             return true;
//         }

//         // Check diagonals
//         if ((a1 == player && b2 == player && c3 == player) ||
//             (a3 == player && b2 == player && c1 == player))
//         {
//             return true;
//         }


//         return false;
//     }
// //     static bool CheckPlace(string[] gamepieces,string input)
// // {
// //     bool placeAvailable = true;

// //     foreach (string piece in gamepieces)
// //     {
// //         if (piece == input)
        
// //             placeAvailable = false;
// //             break;
// //         }
// //     }

// //     return placeAvailable;
// // }

//      }
     

