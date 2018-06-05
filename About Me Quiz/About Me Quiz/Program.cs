using System;

namespace About_Me
{
    class Program
    {
        /*
         * Main Function - This program is a console-based interactive Quiz
         */
        static void Main(string[] args)
        {
            int score = 0;
            int wrong = 0;
            if (Introduction())
            {
                string userName = GetUserName();
                Console.WriteLine($"{userName}, lets begin.");
                if (Question1()) score++;
                else wrong++;

                if (Question2()) score++;
                else wrong++;

                if (Question3()) score++;
                else wrong++;

                if (Question4()) score++;
                else wrong++;

                if (Question5()) score++;
                else wrong++;

                Evaluate(userName, score, wrong);
            }
            Console.WriteLine("Thanks for checking out my program!");
            Console.ReadLine();
        }

        /* Introduction - This method introduces the user to the game and asks them if they would like to play.
         * @return boolean - True if the user would like to play, False if they do not.
         */
        static bool Introduction()
        {
            Console.WriteLine("Welcome to my \'About Me\' Game!");
            Console.WriteLine("This is a chance for you to learn a little bit about me.");
            Console.Write("Want to play? ");
            return (GetResponse("Y", "N").Equals("Y")) ? true : false;
        }

        /* GetUserName - This method requests the users name
         * @return string - User's input name
         */
        static string GetUserName()
        {
            Console.Write("Awesome! What is your name? ");
            return Console.ReadLine();
        }

        /* Question1 - Asks the user a question about me
         * @return boolean isCorrect - True if user got the answer correct, False if user got the answer wrong
         */
        static bool Question1()
        {
            DrawSeperator("Question 1");
            Console.WriteLine("My favorite class in high school was computer science.");
            bool isCorrect = (GetResponse("True", "False").Equals("False"));
            if (isCorrect)
                Console.WriteLine("That's right! Unfortunately Computer Science courses weren't an option in my school.");
            else
                Console.WriteLine("Nope. Unfortunately Computer Science wasn't an option I had in high school.");
            return isCorrect;
        }

        /* Question2 - Asks the user a question about me
         * @return boolean isCorrect - True if user got the answer correct, False if user got the answer wrong
         */
        static bool Question2()
        {
            DrawSeperator("Question 2");
            Console.WriteLine("How long have I lived in Seattle?");
            string one = "6 years.";
            string two = "My whole life.";
            string three = "3 years.";
            string four = "Less than a year.";
            bool isCorrect = (GetResponse(one, two, three, four) == 3);
            if (isCorrect)
                Console.WriteLine("That is right! I moved here after leaving the Army in 2015.");
            else
                Console.WriteLine("Nope. I moved here after leaving the Army in 2015.");
            return isCorrect;
        }

        /* Question3 - Asks the user a question about me
         * @return boolean isCorrect - True if user got the answer correct, False if user got the answer wrong
         */
        static bool Question3()
        {
            DrawSeperator("Question 3");
            Console.WriteLine("My dog is a four year old Belgian Malinois, what is her name?");
            string one = "Penny";
            string two = "Lily";
            string three = "Olivia";
            string four = "Princess Fluffy-butt";

            bool answer = (GetResponse(one, two, three, four) == 2);
            if (answer)
                Console.WriteLine("Thats right. She\'s awesome.");
            else
                Console.WriteLine("Nope. Her name is Lily and she's awesome.");
            return answer;
        }

        /* Question4 - Asks the user a question about me
         * @return boolean isCorrect - True if user got the answer correct, False if user got the answer wrong
         */
        static bool Question4()
        {
            DrawSeperator("Question 4");
            Console.WriteLine("Do I have a twin?");
            bool isCorrect = (GetResponse("Yes", "No").Equals("No"));
            if (isCorrect)
                Console.WriteLine("Thats right, I don\'t have a twin, but my wife does!");
            else
                Console.WriteLine("Nope. I don\'t have a twin, but my wife does!");
            return isCorrect;
        }

        /* Question5 - Asks the user a question about me
         * @return boolean isCorrect - True if user got the answer correct, False if user got the answer wrong
         */
        static bool Question5()
        {
            DrawSeperator("Question 5");
            Console.WriteLine("In my free time, I like to DJ.");
            bool isCorrect = (GetResponse("True", "False").Equals("False"));
            if (isCorrect)
                Console.WriteLine("That right. Unfortunately I don\'t have much musical talent.");
            else
                Console.WriteLine("Nope. Unfortunately I don\'t have much musical talent.");
            return isCorrect;
        }

        /* DrawSeperator - Writes a line to the console to aid in program readability and to add titles
         * @param string content - String representing the title of the following section
         */
        static void DrawSeperator(string content)
        {
            Console.WriteLine($"\n***** {content} *****");
        }

        /* GetResponse - Method that takes two possible options, presents them, retreives a user response, and validates it
         * @param string firstOption - First option presented to user
         * @param string secondOption - Second option presented to user
         * @return string - One of the options provided to the user
         */
        static string GetResponse(string firstOption, string secondOption)
        {
            Console.Write($"{firstOption}/{secondOption}: ");
            string response = Console.ReadLine().ToUpper();
            while (!response.Equals(firstOption.ToUpper()) && !response.Equals(secondOption.ToUpper()))
            {
                Console.WriteLine("I didn\'t get that.");
                response = GetResponse(firstOption, secondOption).ToUpper();
            }
            return (response.Equals(firstOption.ToUpper())) ? firstOption : secondOption;
        }

        /* GetResponse - Method that takes four possible options, presents them, retreives a user response, and validates it
         * @param string optOne - First option presented to user
         * @param string optTwo - Second option presented to user
         * @param string optThree - Third option presented to user
         * @param string optFour - Fourth option presented to user
         * @return int response - Integer representing user's response
         */
        static int GetResponse(string optOne, string optTwo, string optThree, string optFour)
        {
            Console.WriteLine($"1. {optOne}\n2. {optTwo}\n3. {optThree} \n4. {optFour}");
            string response = Console.ReadLine();
            while (response != "1" && response != "2" && response != "3" && response != "4")
            {
                Console.WriteLine("Sorry, that isn't one of the options.");
                response = GetResponse(optOne, optTwo, optThree, optFour).ToString();
            }
            return int.Parse(response);
        }

        /* Evaluate - Method that presents the users cummulative score after answering all questions
         * @param string userName - User's name
         * @param int score - Number of correct responses
         * @param int wrong - Number of incorrect responses
         */
        static void Evaluate(string userName, int score, int wrong)
        {
            DrawSeperator($"{userName}'s Score: {score}/{score + wrong}");
            if (score == 0)
                Console.WriteLine("Sorry, you didn\'t get any questions right.");
            else if (wrong == 0)
                Console.WriteLine("You got all of the questions correct! Nice Job!");
            else
                Console.WriteLine($"You got {score} questions correct.");

        }
    }
}
