using System;

namespace RecipeApp
{
    class Ingredient
    {
        public string Name { get; set; }    // Name of the ingredient
        public double Quantity { get; set; }    // Quantity of the ingredient
        public string Unit { get; set; }   // Unit of measurement for the ingredient
    }

    class Step
    {
        public string Description { get; set; }    // Description of a cooking step
    }

    class Recipe
    {
        private Ingredient[] ingredients;   // Array to store ingredients
        private Step[] steps;   // Array to store cooking steps

        public Ingredient[] Ingredients => ingredients;
        public Step[] Steps => steps;

        public Recipe()
        {
            // Initialize arrays to null initially
            ingredients = null;
            steps = null;
        }

        public void EnterRecipeDetails()
        {
            try
            {
                // Method to enter recipe details
                Console.Write("Enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());
                // Create a new array for ingredients
                ingredients = new Ingredient[numIngredients];
                // Loop to input details for each ingredient
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"\nIngredient {i + 1}:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Quantity: ");
                    double quantity = double.Parse(Console.ReadLine());
                    Console.Write("Unit of measurement: ");
                    string unit = Console.ReadLine();
                    // Create a new Ingredient object and store it in the array
                    ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
                }

                Console.Write("\nEnter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());
                // Create a new array for steps
                steps = new Step[numSteps];
                // Loop to input details for each cooking step
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"\nStep {i + 1}:");
                    Console.Write("Description: ");
                    string description = Console.ReadLine();
                    // Create a new Step object and store it in the array
                    steps[i] = new Step { Description = description };
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
        // Method to display recipe details
        public void DisplayRecipe()
        {
            if (ingredients != null && steps != null)
            {
                Console.WriteLine("\nRecipe Details:");
                Console.WriteLine("Ingredients:");
                // Loop to display each ingredient
                foreach (Ingredient ingredient in ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                }

                Console.WriteLine("\nSteps:");
                // Loop to display each cooking step
                foreach (Step step in steps)
                {
                    Console.WriteLine($"- {step.Description}");
                }
            }
            else
            {
                Console.WriteLine("No recipe entered yet.");
            }
        }
        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            if (ingredients != null)
            {
                // Multiply each ingredient quantity by the scaling factor
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.Quantity *= factor;
                }
            }
            else
            {
                Console.WriteLine("No recipe entered yet.");
            }
        }
        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            // Reset quantities to original values
        }
        // Method to clear the recipe
        public void ClearRecipe()
        {
            // Set arrays to null to clear the recipe
            ingredients = null;
            steps = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                try
                {
                    // Display menu options
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Enter Recipe Details");
                    Console.WriteLine("2. Display Recipe");
                    Console.WriteLine("3. Scale Recipe");
                    Console.WriteLine("4. Reset Quantities");
                    Console.WriteLine("5. Clear Recipe");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:  // Call method to enter recipe details
                            recipe.EnterRecipeDetails();
                            break;
                        case 2:
                            recipe.DisplayRecipe();  // Call method to display recipe details
                            break;
                        case 3:
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                            double factor = double.Parse(Console.ReadLine());
                            recipe.ScaleRecipe(factor);  // Call method to scale recipe
                            break;
                        case 4:
                            recipe.ResetQuantities();   // Call method to reset quantities (not implemented in this example)
                            break;
                        case 5:
                            recipe.ClearRecipe();   // Call method to clear recipe data
                            break;
                        case 6:
                            Environment.Exit(0);    // Exit the application
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }
        }
    }
}

