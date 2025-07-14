using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public double FirstNumber { get; set; }

        [BindProperty]
        public double SecondNumber { get; set; }

        [BindProperty]
        public string Operation { get; set; } = "Add";

        public double? Result { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // Initialize defaults if needed
        }

        public void OnPost()
        {
            try
            {
                switch (Operation)
                {
                    case "Add":
                        Result = FirstNumber + SecondNumber;
                        break;
                    case "Subtract":
                        Result = FirstNumber - SecondNumber;
                        break;
                    case "Multiply":
                        Result = FirstNumber * SecondNumber;
                        break;
                    case "Divide":
                        if (SecondNumber == 0)
                        {
                            ErrorMessage = "Cannot divide by zero.";
                            Result = null;
                        }
                        else
                        {
                            Result = FirstNumber / SecondNumber;
                        }
                        break;
                    default:
                        ErrorMessage = "Invalid operation.";
                        Result = null;
                        break;
                }
            }
            catch
            {
                ErrorMessage = "An error occurred during calculation.";
                Result = null;
            }
        }
    }
}
