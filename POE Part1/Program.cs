using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Ingredient
    {
        public string Name { get; set; }    // Name of the ingredient
        public double Quantity { get; set; }    // Quantity of the ingredient
        public string Unit { get; set; }   // Unit of measurement for the ingredient
        public int Calories { get; set; }  // Calories of the ingredient
        public string FoodGroup { get; set; } // Food group of the ingredient
    }

    class Step
    {
        public string Description { get; set; }    // Description of a cooking step
    }

    class Recipe
    {
        public string Name { get; set; } // Name of the recipe
        private List<Ingredient> ingredients;   // List to store ingredients
        private List<Step> steps;   // List to store cooking steps

        public Recipe()
        {
            ingredients = new List<Ingredient>(); // Initialize the list
            steps = new List<Step>(); // Initialize the list
        }

        // Method to calculate and return the total calories of all ingredients
        public int TotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                totalCalories += ingredient.Calories * (int)ingredient.Quantity;
            }
            return totalCalories;
        }

        public void EnterRecipeDetails()
        {
            Console.Write("Enter the name of the recipe: ");
            Name = Console.ReadLine();

            try
            {
                // Method to enter recipe details
                Console.Write("Enter the number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());

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
                    Console.Write("Calories per unit: ");
                    int calories = int.Parse(Console.ReadLine());
                    Console.Write("Food group: ");
                    string foodGroup = Console.ReadLine();

                    // Create a new Ingredient object and add it to the list
                    ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
                }

                Console.Write("\nEnter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());
                // Create a new array for steps
                steps = new List<Step>(numSteps);
                // Loop to input details for each cooking step
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"\nStep {i + 1}:");
                    Console.Write("Description: ");
                    string description = Console.ReadLine();
                    // Create a new Step object and store it in the array
                    steps.Add(new Step { Description = description });
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }

        public void DisplayRecipe()
        {
            if (ingredients.Count > 0 && steps.Count > 0)
            {
                Console.WriteLine($"\nRecipe Details - {Name}:");

                // Display ingredients
                Console.WriteLine("Ingredients:");
                foreach (Ingredient ingredient in ingredients)
                {
                    Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories per {ingredient.Unit}, {ingredient.FoodGroup})");
                }

                // Display steps
                Console.WriteLine("\nSteps:");
                foreach (Step step in steps)
                {
                    Console.WriteLine($"- {step.Description}");
                }

                // Calculate and display total calories
                int totalCalories = TotalCalories();
                Console.WriteLine($"\nTotal Calories: {totalCalories}");

                // Notify if total calories exceed 300
                if (totalCalories > 300)
                {
                    Console.WriteLine("Warning: Total calories exceed 300!");
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
            if (ingredients.Count > 0)
            {
                // Multiply each ingredient quantity by the scaling factor
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.Quantity *= factor;
                }
            }
            else
            {
                Console.WriteLine("No ingredients in the recipe.");
            }
        }

        // Method to reset ingredient quantities to original values
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                // Reset each ingredient quantity to 1
                ingredient.Quantity = 1;
            }
        }

        // Method to edit the recipe
        public void EditRecipe()
        {
            EnterRecipeDetails();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                try
                {
                    // Display menu options
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Enter Recipe Details");
                    Console.WriteLine("2. Display Recipe");
                    Console.WriteLine("3. Edit Recipe");
                    Console.WriteLine("4. Scale Recipe");
                    Console.WriteLine("5. Reset Quantities");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:  // Call method to enter recipe details
                            Recipe newRecipe = new Recipe();
                            newRecipe.EnterRecipeDetails();
                            recipes.Add(newRecipe);
                            break;
                        case 2:
                            Console.WriteLine("\nRecipes:");
                            // Sort recipes alphabetically by name
                            List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
                            foreach (Recipe recipe in sortedRecipes)
                            {
                                Console.WriteLine($"- {recipe.Name}");
                            }
                            Console.Write("Enter the name of the recipe to display: ");
                            string recipeName = Console.ReadLine();
                            Recipe selectedRecipe = sortedRecipes.Find(r => r.Name == recipeName);
                            if (selectedRecipe != null)
                            {
                                selectedRecipe.DisplayRecipe();  // Call method to display recipe details
                            }
                            else
                            {
                                Console.WriteLine("Recipe not found.");
                            }
                            break;
                        case 3:
                            Console.Write("Enter the name of the recipe to edit: ");
                            string recipeToEditName = Console.ReadLine();
                            Recipe recipeToEdit = recipes.Find(r => r.Name == recipeToEditName);
                            if (recipeToEdit != null)
                            {
                                recipeToEdit.EditRecipe(); // Call method to edit the recipe
                            }
                            else
                            {
                                Console.WriteLine("Recipe not found.");
                            }
                            break;
                        case 4:
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                            double factor = double.Parse(Console.ReadLine());
                            Console.Write("Enter the name of the recipe to scale: ");
                            string recipeToScale = Console.ReadLine();
                            Recipe recipeToScaleObj = recipes.Find(r => r.Name == recipeToScale);
                            if (recipeToScaleObj != null)
                            {
                                recipeToScaleObj.ScaleRecipe(factor);  // Call method to scale recipe
                            }
                            else
                            {
                                Console.WriteLine("Recipe not found.");
                            }
                            break;
                        case 5:
                            Console.Write("Enter the name of the recipe to reset quantities: ");
                            string recipeToReset = Console.ReadLine();
                            Recipe recipeToResetObj = recipes.Find(r => r.Name == recipeToReset);
                            if (recipeToResetObj != null)
                            {
                                recipeToResetObj.ResetQuantities();   // Call method to reset quantities
                            }
                            else
                            {
                                Console.WriteLine("Recipe not found.");
                            }
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
