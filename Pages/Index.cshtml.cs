using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guessing_Game.Pages // Ensure this namespace matches your project name
{
    public class IndexModel : PageModel
    {
        private static int secretNumber;
        private static int numberOfGuesses;

        [BindProperty]
        public int Guess { get; set; }

        public string Message { get; private set; }
        public bool IsGameOver { get; private set; }

        // Expose numberOfGuesses through a public property
        public int NumberOfGuesses => numberOfGuesses;

        public void OnGet()
        {
            secretNumber = new Random().Next(1, 101);
            numberOfGuesses = 0;
            IsGameOver = false;
        }

        public void OnPost()
        {
            numberOfGuesses++;

            if (Guess < secretNumber)
            {
                Message = "Your guess is too low. Try again.";
            }
            else if (Guess > secretNumber)
            {
                Message = "Your guess is too high. Try again.";
            }
            else
            {
                Message = "Correct!";
                IsGameOver = true;
            }
        }
    }
}
