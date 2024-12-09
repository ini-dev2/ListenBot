using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ListenBot.Scripts
{
    internal class Utils
    {
        private string command;

        public string ExecuteCommand(double result)
        {
            command = $"tv_listen_voice_indices {result}";
            return command;
        }

        public List<int> GetNumber(TextBox textBox)
        {
            string[] lines = textBox.Lines;
            List<int> playerId = new List<int>();

            Regex regex = new Regex(@"spec_player\s(\d+)");

            foreach (string line in lines)
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    playerId.Add(int.Parse(match.Groups[1].Value));
                }
            }
            return playerId;
        }
    }
}