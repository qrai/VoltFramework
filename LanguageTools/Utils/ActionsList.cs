using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageTools.Utils
{
    public class DescribedAction
    {
        public string TOKEN_NAME { get; set; }
        /// <summary>
        /// All tokens in code and current token index
        /// </summary>
        public Action<Token[],int> Action { get; set; }
        public DescribedAction(string tokenName,Action<Token[],int> act)
        {
            TOKEN_NAME = tokenName;
            Action = act;
        }
    }
    public class ActionsList
    {
        private List<DescribedAction> Actions;

        public ActionsList()
        {
            Actions = new List<DescribedAction>();
        }

        public void AddAction(DescribedAction a)
        {
            Actions.Add(a);
        }
        public void AddAction(string tokName,Action<Token[],int> act)
        {
            Actions.Add(new DescribedAction(tokName, act));
        }
        public List<DescribedAction> GetList()
        {
            return Actions;
        }
    }
}
