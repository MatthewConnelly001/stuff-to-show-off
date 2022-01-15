using System;
using System.Collections.Generic;


static class Controller
{
    private const string TAKE_INPUT = "take";
    private const string ADD_INPUT = "add";
    private const string SHOWBASKET_INPUT = "show";
    private const string HELP_INPUT = "help";
    private const string EXIT_INPUT = "exit";

    private static Dictionary<string, string> inputDescriptions = new Dictionary<string, string>{
        {$"{TAKE_INPUT} <item>", "Takes an item from the basket."},
        {$"{ADD_INPUT} <item>", "Adds an item to the basket."},
        {SHOWBASKET_INPUT, "Displays all items in the basket."},
        {HELP_INPUT, "Displays information about this app and input commands."},
        {EXIT_INPUT, "Closes the application"},
    };


    public static void InputLoop()
    {
        // Initially displaying help to be helpful!
        View.DisplayHelp(inputDescriptions);

        // Main input loop
        string[] inputTokens = { };
        while(true)
        {
            inputTokens = View.Input().ToLower().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            // This will never occur due to split function.
            if (inputTokens.Length == 0)
            {
                View.DisplayNoInput();
            }

            // Selecting command made from first input token.
            switch(inputTokens[0])
            {
                case HELP_INPUT:
                    View.DisplayHelp(inputDescriptions);
                    break;
                case TAKE_INPUT:
                    Model.TakeItem( (inputTokens.Length >= 2) ? inputTokens[1] : null );
                    break;
                case ADD_INPUT:
                    Model.AddItem( (inputTokens.Length >= 2) ? inputTokens[1] : null );
                    break;
                case SHOWBASKET_INPUT:
                    View.DisplayShowBasket(Model.basket);
                    break;
                case EXIT_INPUT:
                    return;
                default:
                    View.DisplayUnknownInput(inputTokens[0]);
                    break;
            }
        }
    }
}