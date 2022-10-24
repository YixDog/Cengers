//Defining important variables.
string[] chart = new string[64];
for (int i = 0; i < chart.Length; i++)
    chart[i] = ".";
chart[0] = "O";
chart[1] = "O";
chart[2] = "O";
chart[8] = "O";
chart[9] = "O";
chart[10] = "O";
chart[16] = "O";
chart[17] = "O";
chart[18] = "O";
chart[63] = "X";
chart[62] = "X";
chart[61] = "X";
chart[55] = "X";
chart[54] = "X";
chart[53] = "X";
chart[47] = "X";
chart[46] = "X";
chart[45] = "X";
int flag = 0;
string element_of_array = "";
int currentx = 4;
int currenty = 2;
int currentx1 = 4;
int currenty1 = 2;
int cursorx = 4;
int cursory = 2;
int currentposition = 0;
int roundcounter = 1;
//PrintScreen Function
void PrintScreen()
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("    1 2 3 4 5 6 7 8");
    Console.Write("  + - - - - - - - - +");
    //Printing chart
    for (int i = 0; i < chart.Length; i++)
    {


        if ((i) % 8 == 0)
        {
            Console.WriteLine("");
            Console.Write((i + 8) / 8 + " " + "| " + chart[i] + " ");
        }
        else
        {
            Console.Write(chart[i] + " "); ;
        }
        if ((i + 1) % 8 == 0)
        {
            Console.Write("|");
        }





    }
    Console.WriteLine("");
    Console.WriteLine("  + - - - - - - - - +");
    Console.SetCursorPosition(25, 4);
    //Printing round.
    Console.WriteLine("Round: " + roundcounter);
    Console.SetCursorPosition(25, 5);
}
//PrintScreenPlayer Function
void PrintScreenPlayer()
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("    1 2 3 4 5 6 7 8");
    Console.Write("  + - - - - - - - - +");
    //Printing chart.
    for (int i = 0; i < chart.Length; i++)
    {

        if ((i) % 8 == 0)
        {
            Console.WriteLine("");
            if (currentposition - ((cursorx - 4) / 2) == i)
            {   //Changing color instantly when it requiered while printing chart.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write((i + 8) / 8 + " " + "| " + chart[i] + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write((i + 8) / 8 + " " + "| " + chart[i] + " ");
            }

        }
        else
        {
            if (currentposition - ((cursorx - 4) / 2) == i)
            {
                //Changing color instantly when it requiered while printing chart.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(chart[i] + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(chart[i] + " ");
            }
        }
        if ((i + 1) % 8 == 0)
        {
            Console.Write("|");
        }

    }
    Console.WriteLine("");
    Console.WriteLine("  + - - - - - - - - +");
    Console.SetCursorPosition(25, 4);
    //Printing round.
    Console.WriteLine("Round: " + roundcounter);
    Console.SetCursorPosition(25, 5);
}

Console.SetCursorPosition(cursorx, cursory);

PrintScreen();
Console.WriteLine("Turn: X");
while (true)
{
    //reset cursor to last position
    Console.SetCursorPosition(cursorx, cursory);
    ConsoleKeyInfo info = Console.ReadKey(true);
    Console.SetCursorPosition(cursorx, cursory);
    if (info.Key != ConsoleKey.RightArrow && info.Key != ConsoleKey.LeftArrow && info.Key != ConsoleKey.UpArrow && info.Key != ConsoleKey.DownArrow && info.KeyChar != 99 && info.KeyChar != 120 && info.KeyChar != 122 && info.KeyChar != 67 && info.KeyChar != 88 && info.KeyChar != 90)
    {
        Console.SetCursorPosition(0, 12);
        Console.WriteLine("\nYou can use only z,x,c buttons and arrow keys");
        Console.SetCursorPosition(cursorx, cursory);
    }
    currentposition = (cursory - 2) * 8 + cursorx - 4;
    //ARROWKEYS

    if (info.Key == ConsoleKey.RightArrow & (cursorx < 18))
    {
        cursorx += 2;
        Console.SetCursorPosition(cursorx, cursory);
    }
    else if (info.Key == ConsoleKey.LeftArrow & (cursorx > 4))
    {
        cursorx -= 2;
        Console.SetCursorPosition(cursorx, cursory);
    }
    else if (info.Key == ConsoleKey.UpArrow & cursory > 2)
    {
        cursory -= 1;
        Console.SetCursorPosition(cursorx, cursory);
    }
    else if (info.Key == ConsoleKey.DownArrow & cursory < 9)
    {
        cursory += 1;
        Console.SetCursorPosition(cursorx, cursory);
    }//Z and X keys.
    if (info.Key == ConsoleKey.Z && (chart[currentposition - ((cursorx - 4) / 2)] == "X") && flag == 0)
    {

        currentx = cursorx;
        currenty = cursory;
        element_of_array = chart[currentposition - ((cursorx - 4) / 2)];
        flag = 1;
        PrintScreenPlayer();

    }
    if ((info.Key == ConsoleKey.X && (chart[currentposition - ((cursorx - 4) / 2)] == ".")) && flag == 1
        && ((currentx == cursorx + 2 && cursory == currenty) || (currentx == cursorx - 2 && cursory == currenty)
        || (currentx == cursorx && cursory - 1 == currenty) || (currentx == cursorx && cursory + 1 == currenty)))
    {

        chart[currentposition - ((cursorx - 4) / 2)] = element_of_array;
        chart[currentx - 4 + (currenty - 2) * 8 - ((currentx - 4) / 2)] = ".";
        flag = 2;

        Console.Clear();
        PrintScreenPlayer();
        Console.WriteLine("Turn: X");
        Console.SetCursorPosition(25, 7);
        Console.WriteLine("Press 'C' to pass turn");

    }//Double jump part 1
    if ((info.Key == ConsoleKey.X && ((chart[currentposition - ((cursorx - 4) / 2)] == "X") || chart[currentposition - ((cursorx - 4) / 2)] == "O"))
        && flag == 1 && ((currentx == cursorx + 2 && cursory == currenty) || (currentx == cursorx - 2 && cursory == currenty)
        || (currentx == cursorx && cursory - 1 == currenty) || (currentx == cursorx && cursory + 1 == currenty)))
    {
        currentx1 = cursorx;
        currenty1 = cursory;
        flag = 3;
        PrintScreenPlayer();
        Console.WriteLine("Turn: X");
    }
    //Double jump part 2
    if ((info.Key == ConsoleKey.X && (chart[currentposition - ((cursorx - 4) / 2)] == ".")) && flag == 3
        && ((currentx1 == cursorx + 2 && cursory == currenty1) || (currentx1 == cursorx - 2 && cursory == currenty1)
        || (currentx1 == cursorx && cursory - 1 == currenty1) || (currentx1 == cursorx && cursory + 1 == currenty1)))
    {

        chart[currentposition - ((cursorx - 4) / 2)] = element_of_array;
        chart[currentx - 4 + (currenty - 2) * 8 - ((currentx - 4) / 2)] = ".";
        flag = 2;
        Console.Clear();
        PrintScreenPlayer();
        Console.WriteLine("Turn: X");
        Console.SetCursorPosition(25, 7);
        Console.WriteLine("Press 'C' to pass turn");



    }
    else if ((info.Key == ConsoleKey.X && (chart[currentposition - ((cursorx - 4) / 2)] != ".")) && flag == 3
        && ((currentx1 == cursorx + 2 && cursory == currenty1) || (currentx1 == cursorx - 2 && cursory == currenty1)
        || (currentx1 == cursorx && cursory - 1 == currenty1) || (currentx1 == cursorx && cursory + 1 == currenty1)))
    {
        currentx1 = cursorx;
        currenty1 = cursory;

        flag = 3;
        ;
        PrintScreenPlayer();
        Console.WriteLine("Turn: X");

    }
    // C key.
    if (info.Key == ConsoleKey.C && flag == 2)
    {
        // Defining variables that will be used in computer movement parts.
        flag = 0;
        roundcounter++;
        string temp_piece;
        bool step_made = false;
        Random rand = new Random();

        int comp_direction = rand.Next(1, 3); // Random number for choosing random move to left or up.
        int comp_piece;
        int compX;
        int compY;
        Console.SetCursorPosition(25, 4);
        Console.WriteLine("Round: " + roundcounter);
        Console.SetCursorPosition(25, 5);
        Console.WriteLine("Turn: O");
        Console.SetCursorPosition(cursorx, cursory);
        Thread.Sleep(500);

        do // Try moves for computer until it founds the right move.
        {
            int[] gain = new int[chart.Length]; // An array for gains of every computer piece.



            for (comp_piece = 0; comp_piece < gain.Length; comp_piece++) // Calculating gains of every computer piece
            {
                if (chart[comp_piece] == "O")
                {
                    compX = ((comp_piece) % 8) * 2 + 2;
                    compY = ((comp_piece + 1) / 8) + 2;

                    // gains of the moves that start with right direction
                    if ((comp_piece + 2) < 64 && chart[comp_piece + 1] != "." && chart[comp_piece + 2] == ".") // jump right
                    {
                        gain[comp_piece] = 21;

                        if (compX < 10 && chart[comp_piece + 3] != "." && chart[comp_piece + 4] == ".") //double jump right right
                        {
                            gain[comp_piece] = 41;
                        }

                        if ((comp_piece + 18) < 64 && gain[comp_piece] == 41 && compX < 14 && compY < 8 && chart[comp_piece + 10] != "." && chart[comp_piece + 18] == ".") 	// If double jump right right and double jump right down
                        {																			// are both available, random choosing between them.
                            int dj_rd = rand.Next(1, 3);
                            if (dj_rd == 1)
                                gain[comp_piece] = 41;
                            else
                                gain[comp_piece] = 42;
                        }
                        else if ((comp_piece + 18) < 64 && compX < 14 && compY < 8 && chart[comp_piece + 10] != "." && chart[comp_piece + 18] == ".") // double jump right down
                        {
                            gain[comp_piece] = 42;
                        }

                    }
                    else if (compX < 18 && (comp_piece + 1) < 64 && chart[comp_piece + 1] == ".") // step right
                    {
                        gain[comp_piece] = 11;
                    }
                    else // no gains for now
                    {
                        gain[comp_piece] = 0;
                    }

                    // moves start with down
                    if ((comp_piece + 16) < 64 && compX < 14 && compY < 8 && chart[comp_piece + 8] != "." && chart[comp_piece + 16] == ".") 	// If jump right and jump down
                    {																// are both available, random choosing between them.
                        if (gain[comp_piece] == 21)
                        {
                            int jump_dir = rand.Next(1, 3);
                            if (jump_dir == 1)
                                gain[comp_piece] = 21;
                            else
                                gain[comp_piece] = 22;
                        }
                        else
                        {
                            gain[comp_piece] = 22;
                        }

                        if ((comp_piece + 18) < 64 && compX < 16 && compY < 8 && chart[comp_piece + 17] != "." && chart[comp_piece + 18] == ".") // double jump down right
                        {
                            gain[comp_piece] = 43;
                        }


                        if ((comp_piece + 32) < 64 && gain[comp_piece] == 43 && compY < 6 && chart[comp_piece + 24] != "." && chart[comp_piece + 32] == ".")    // If double jump down down and double jump down right
                        {                                                                   // are both available, random choosing between them.

                            int dj_d = rand.Next(1, 3);
                            if (dj_d == 1)
                                gain[comp_piece] = 43;
                            else
                                gain[comp_piece] = 44;
                        }
                        else if ((comp_piece + 32) < 64 && compY < 6 && chart[comp_piece + 24] != "." && chart[comp_piece + 32] == ".") // If only double jump down down is available, no need choosing.
                        {
                            gain[comp_piece] = 44;
                        }
                        if ((gain[comp_piece] == 41 || gain[comp_piece] == 42) && (gain[comp_piece] == 43 || gain[comp_piece] == 44)) // If more than one double jump is available, random choose.
                        {
                            int doublej_rand = rand.Next(1, 3);
                            if (doublej_rand == 1 && gain[comp_piece] == 41)
                                gain[comp_piece] = 41;
                            else if (doublej_rand == 1 && gain[comp_piece] == 42)
                                gain[comp_piece] = 42;
                            else if (doublej_rand == 2 && gain[comp_piece] == 43)
                                gain[comp_piece] = 43;
                            else if (doublej_rand == 2 && gain[comp_piece] == 44)
                                gain[comp_piece] = 44;
                        }
                    }
                    else if (compY < 8 && (comp_piece + 8) < 64 && gain[comp_piece] == 11 && chart[comp_piece + 8] == ".") 	// If step down and step right
                    {                                                       // are both available, random choosing between them.

                        int s_ld = rand.Next(1, 3);
                        if (s_ld == 1)
                            gain[comp_piece] = 11;
                        else
                            gain[comp_piece] = 12;
                    }
                    else if (compY < 8 && (comp_piece + 8) < 64 && chart[comp_piece + 8] == ".") // If only step down is available, no need choosing.
                    {
                        gain[comp_piece] = 12;
                    }
                    else if (gain[comp_piece] == 0)   // no gains
                    {
                        gain[comp_piece] = 0;
                    }
                }
            }

            do // Now doing the moves
            {
                int piece_tried = 0;

                do
                {

                    bool skip = false;
                    while (step_made == false && skip == false && piece_tried < 9) // Looking for a piece with more gains by doing double jump.
                    {

                        int comp_move = rand.Next(0, 64);
                        int[] choosen = new int[14]; // If a piece is chosen before in the same round, skip it
                        if (chart[comp_move] == "O")
                        {
                            for (int i = 0; i < piece_tried + 2; i++)
                            {
                                if (comp_move == choosen[i])
                                {
                                    skip = true;
                                }
                            }

                            compX = (comp_move + 1) % 8;
                            compY = (comp_move + 1) / 8;

                            switch (gain[comp_move]) // Looking for double jump move gains.
                            {
                                case 41: // double jump right right
                                    temp_piece = chart[comp_move];
                                    chart[comp_move + 2] = temp_piece;
                                    chart[comp_move] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    Thread.Sleep(200);
                                    chart[comp_move + 4] = temp_piece;
                                    chart[comp_move + 2] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    step_made = true;
                                    compX += 8;
                                    break;
                                case 42: // double jump right down
                                    temp_piece = chart[comp_move];
                                    chart[comp_move + 2] = temp_piece;
                                    chart[comp_move] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    Thread.Sleep(200);
                                    chart[comp_move + 18] = temp_piece;
                                    chart[comp_move + 2] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    step_made = true;
                                    compX += 4;
                                    compY += 2;
                                    break;
                                case 43: // double jump down right
                                    temp_piece = chart[comp_move];
                                    chart[comp_move + 16] = temp_piece;
                                    chart[comp_move] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    Thread.Sleep(200);
                                    chart[comp_move + 18] = temp_piece;
                                    chart[comp_move + 16] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    step_made = true;
                                    compX += 4;
                                    compY += 2;
                                    break;
                                case 44: // double jump down down
                                    temp_piece = chart[comp_move];
                                    chart[comp_move + 16] = temp_piece;
                                    chart[comp_move] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    Thread.Sleep(200);
                                    chart[comp_move + 32] = temp_piece;
                                    chart[comp_move + 16] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    step_made = true;
                                    compY += 4;
                                    break;

                            }
                            piece_tried++;
                            choosen[piece_tried] = comp_move;
                        }
                        if (step_made == true)
                        {
                            gain[comp_move] = 0;
                        }
                    }

                } while (piece_tried < 9 && step_made == false);

                piece_tried = 0;
                if (step_made == false) // If no double jump moves are available, try jumps.
                {
                    do
                    {
                        bool skip = false;
                        while (step_made == false && skip == false && piece_tried < 9)  // Looking for a piece that can do jump.
                        {
                            int comp_move = rand.Next(0, 64);
                            int[] choosen = new int[14];
                            if (chart[comp_move] == "O")
                            {
                                for (int i = 0; i < piece_tried + 2; i++)
                                {
                                    if (comp_move == choosen[i])
                                    {
                                        skip = true;
                                    }
                                }

                                compX = (comp_move + 1) % 8;
                                compY = (comp_move + 1) / 8;

                                switch (gain[comp_move])  // Looking for jump move gains.
                                {
                                    case 21: // jump right
                                        temp_piece = chart[comp_move];
                                        chart[comp_move + 2] = temp_piece;
                                        chart[comp_move] = ".";
                                        Console.Clear();
                                        PrintScreen();
                                        Console.WriteLine("Turn: X");
                                        step_made = true;
                                        compX += 4;
                                        break;
                                    case 22: // jump down
                                        temp_piece = chart[comp_move];
                                        chart[comp_move + 16] = temp_piece;
                                        chart[comp_move] = ".";
                                        Console.Clear();
                                        PrintScreen();
                                        Console.WriteLine("Turn: X");
                                        step_made = true;
                                        compY += 2;
                                        break;
                                }
                                piece_tried++;
                                choosen[piece_tried] = comp_move;

                            }
                            if (step_made == true)
                            {
                                gain[comp_move] = 0;
                            }
                        }
                    } while (piece_tried < 9 && step_made == false);
                }

                piece_tried = 0;
                if (step_made == false)
                {
                    do
                    {
                        bool skip = false;
                        while (step_made == false && skip == false && piece_tried < 9) // Looking for a piece that can do step moves.
                        {
                            int comp_move = rand.Next(0, 64);
                            int[] choosen = new int[9];
                            if (chart[comp_move] == "O")
                            {
                                for (int i = 0; i < piece_tried + 2; i++)
                                {
                                    if (comp_move == choosen[i])
                                    {
                                        skip = true;
                                    }
                                }

                                compX = (comp_move + 1) % 8;
                                compY = (comp_move + 1) / 8;

                                switch (gain[comp_move])  // Looking for step move gains.
                                {
                                    case 11: // step right
                                        temp_piece = chart[comp_move];
                                        chart[comp_move + 1] = temp_piece;
                                        chart[comp_move] = ".";
                                        Console.Clear();
                                        PrintScreen();
                                        Console.WriteLine("Turn: X");
                                        step_made = true;
                                        compX += 2;
                                        break;
                                    case 12: // step down
                                        temp_piece = chart[comp_move];
                                        chart[comp_move + 8] = temp_piece;
                                        chart[comp_move] = ".";
                                        Console.Clear();
                                        PrintScreen();
                                        Console.WriteLine("Turn: X");
                                        step_made = true;
                                        compY += 1;
                                        break;

                                }
                                piece_tried++;
                                choosen[piece_tried] = comp_move;
                            }
                            if (step_made == true)
                            {
                                gain[comp_move] = 0;
                            }
                        }
                    } while (piece_tried < 9 && step_made == false);
                }

                if (step_made == false) // Couldn't go down or right. So it needs to go up or left. But as step.
                {
                    int comp_move = rand.Next(0, 64);
                    if (chart[comp_move] == "O")
                    {
                        compX = (comp_move + 1) % 8;
                        compY = (comp_move + 1) / 8;

                        switch (comp_direction)
                        {
                            case 1: //Go left
                                if (compX > 4 && chart[comp_move - 1] == ".")
                                {

                                    temp_piece = chart[comp_move];
                                    chart[comp_move - 1] = temp_piece;
                                    chart[comp_move] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    compX -= 2;
                                    step_made = true;
                                }
                                break;
                            case 2: //Go up
                                if (compY > 2 && chart[comp_move - 8] == ".")
                                {

                                    temp_piece = chart[comp_move];
                                    chart[comp_move - 8] = temp_piece;
                                    chart[comp_move] = ".";
                                    Console.Clear();
                                    PrintScreen();
                                    Console.WriteLine("Turn: X");
                                    compY -= 1;
                                    step_made = true;
                                }
                                break;
                        }


                        if (step_made == false) // It will try the last option's other. If it couldn't go up, it will go  left. Or if it couldnT go left, it will go up.
                        {
                            switch (comp_direction)
                            {
                                case 1: //Go up
                                    if (compY > 2 && chart[comp_move - 8] == ".")
                                    {

                                        temp_piece = chart[comp_move];
                                        chart[comp_move - 8] = temp_piece;
                                        chart[comp_move] = ".";
                                        Console.Clear();
                                        PrintScreen();
                                        Console.WriteLine("Turn: X");
                                        compY -= 1;
                                        step_made = true;
                                    }
                                    break;
                                case 2: // Go left
                                    if (compX > 4 && chart[comp_move - 1] == ".")
                                    {

                                        temp_piece = chart[comp_move];
                                        chart[comp_move - 1] = temp_piece;
                                        chart[comp_move] = ".";
                                        Console.Clear();
                                        PrintScreen();
                                        Console.WriteLine("Turn: X");
                                        compX -= 2;
                                        step_made = true;
                                    }
                                    break;
                            }
                            temp_piece = "";
                        }

                    }

                    if (step_made == true) // Deleting the gain of the moved piece.
                    {
                        gain[comp_move] = 0;
                    }
                }




            } while (step_made == false);

        } while (step_made == false);

        //Game ending one of the players wins and pressing the screen
        Console.SetCursorPosition(cursorx, cursory);
        int winner = 3;

        if (chart[0] == "X" & chart[0 + 1] == "X" & chart[0 + 2] == "X" &
            chart[8] == "X" & chart[8 + 1] == "X" & chart[8 + 2] == "X" &
            chart[16] == "X" & chart[16 + 1] == "X" & chart[16 + 2] == "X")
            winner = 1;

        if (chart[61] == "O" & chart[61 + 1] == "O" & chart[61 + 2] == "O" &
            chart[53] == "O" & chart[53 + 1] == "O" & chart[55 + 2] == "O" &
            chart[45] == "O" & chart[45 + 1] == "O" & chart[45 + 2] == "O")
            winner = 0;
        if (winner == 0)
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine(@"GAME OVER
WINNER IS COMPUTER");
            Console.WriteLine(@"--------------
Please press any key to log out.");
            Console.ReadLine();
            break;
        }
        if (winner == 1)
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine(@"GAME OVER
THE WINNER IS PLAYER");
            Console.WriteLine(@"--------------
Please press any key to log out.");
            Console.ReadLine();
            break;
        }


    }
}
