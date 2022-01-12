using System;
using System.Collections.Generic;


static class Controller
{
    private const string takeInput = "take";
    private const string addInput = "add";
    private const string showBasketInput = "show";
    private const string helpInput = "help";
    private const string exitInput = "exit";

    private static Dictionary<string, string> inputDescriptions = new Dictionary<string, string>{
        {$"{takeInput} <item>", "Takes an item from the basket."},
        {$"{addInput} <item>", "Adds an item to the basket."},
        {showBasketInput, "Displays all items in the basket."},
        {helpInput, "Displays information about this app and input commands."},
        {exitInput, "Closes the application"},
    };


    public static void InputLoop()
    {
        // Initially displaying help to be helpful!
        View.DisplayHelp(inputDescriptions);

        // Main input loop
        string[] inputTokens = { };
        while(true)
        {
            inputTokens = View.Input(); 

            if (inputTokens.Length == 0)
            {
                View.DisplayNoInput();
            }

            switch(inputTokens[0])
            {
                case helpInput:
                    View.DisplayHelp(inputDescriptions);
                    break;
                case takeInput:
                    Model.TakeItem( (inputTokens.Length >= 2) ? inputTokens[1] : null );
                    break;
                case addInput:
                    Model.AddItem( (inputTokens.Length >= 2) ? inputTokens[1] : null );
                    break;
                case showBasketInput:
                    View.DisplayShowBasket(Model.basket);
                    break;
                case exitInput:
                    return;
                default:
                    View.DisplayUnknownInput(inputTokens[0]);
                    break;
            }
        }
    }
}