using System;
using System.Media;
using System.Security.Cryptography;
using System.Windows;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        ChatBot bot = new ChatBot();
        string favoriteContent = "";
        public MainWindow()
        {
            InitializeComponent();

            ChatDisplay.AppendText("Welcome to the Cybersecurity Awareness Chatbot!\n\n"); }

      

            

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text;

            ChatDisplay.AppendText("You: " + userMessage + "\n");
            if (userMessage.ToLower().Contains("phishing"))
            {
                favoriteContent = "phishing";
            }

            else if (userMessage.ToLower().Contains("password"))
            {
                favoriteContent = "password safety";
            }
            string response = bot.Bot(userMessage);
            if (favoriteContent != "")
            {
                response += "\nI remember you're interested in " + favoriteContent + ".";
            }
            ChatDisplay.AppendText("Bot: " + response + "\n\n");

            UserInput.Clear();
        }
    } 
}

    class ChatBot
    {
        Random random = new Random();
        class Sound
        {
            public void GreetingVoice()
            {
                try
                {
                    SoundPlayer player = new SoundPlayer("Recording_2 - Copy.wav");
                    player.Load();
                    player.PlaySync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public string Bot(string message)
        {
            message = message.ToLower();

            if (message.Contains("worried") || message.Contains("scared"))
            {
                return "It's understandable to feel worried. Staying informed helps you stay safe online. I might not be a human being but I can relate to this kind of situations.";
            }

            else if (message.Contains("curious"))
            {
                return "Great question! Learning about cybersecurity is very important. It will save you lots of truoble in the future.";
            }

            else if (message.Contains("frustrated") || message.Contains("confused"))
            {
                return "Don't worry, cybersecurity can be confusing at first. I'll try to simplify it for you. Just tell me what you do not really understand. ";
            }

            if (message.Contains("how are you"))
                return "I am doing great, thanks for asking!";

            else if (message.Contains("purpose"))
                return "My purpose is to promote cybersecurity awareness.";

            else if (message.Contains("what can i ask"))
                return "You can ask about password safety, phishing, scams, privacy  and safe browsing.";

            else if (message.Contains("password"))
            {
                string[] passwordResponses =
                {
                "Use strong passwords. Do you want ways to make strong passwords?",
                "Make your passwords unique and long. Probably 13 characters is enough with mixed special characters and symbols ",
                "Avoid using personal information in passwords. You cannot make things easier for hackers."
            };

                return passwordResponses[random.Next(passwordResponses.Length)];
            }

            else if (message.Contains("phishing"))
                return "Phishing is when attackers trick you into revealing personal information through fake messages or websites. Would you like tips on phising?";

            else if (message.Contains("safe browsing"))
                return "Safe browsing means avoiding suspicious websites and not clicking unknown links. I can show examples of unknown links you should not press. Just say the word.";
            else if (message.Contains("scam"))
            {
                string[] scamResponses =
                {
        "Be careful of online scams asking for personal information. This online scams often look legitimate. I can show you an example by making myself one of the online platforms that provide scams.",
        "Never share banking details with suspicious websites. Do you want tips on avoiding online fraud?",
        "Scammers often pretend to be trusted companies. Would you like advice on spotting fake emails?",
        "Avoid clicking links from unknown messages.  Would you like to learn how phishing scams work?",
        "If something sounds too good to be true, it probably is."
    };

                return scamResponses[random.Next(scamResponses.Length)];
            }
            else if (message.Contains("privacy"))
            {
                string[] privacyResponses =
                    {"Sensitive information should get hidden. Should i give you ways on how to secure sensitive information?",
                    "Watch out for human engineering that can get information stolen. Should i show you techniques they use to convince you to give up information?  ",
                     "Protect information by limimting personal information on online accounts. This is really important than you realize."};

                return privacyResponses[random.Next(privacyResponses.Length)];
            }
            else
                return "Sorry, I don’t understand. Try asking about passwords, phishing, safe browsing or other cybersecurity related topics.";
        }
    }

//Introducing OpenAI(2023)


