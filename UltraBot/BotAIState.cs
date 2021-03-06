﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraBot
{

    public abstract class BotAIState
    {
        private IEnumerator<string> _iterator = null;
        private bool _finished = false;
        protected string _reason = "";
        public string Process(Bot bot)
        {   
            if(_iterator == null)
                _iterator = Run(bot);
            bool hasElements = false;
            try
            {
                hasElements = _iterator.MoveNext();
            }
            catch(InvalidOperationException e)
            {
                hasElements = false;
                _reason = "InvalidOperationException?";
            }
            if(hasElements)
                return _iterator.Current;
            else
            {
                _finished = true;
                return String.Format("{0} exit: {1}", this.GetType().Name, _reason);
            }
        }
        public bool isFinished()
        {
            return _finished;
        }
        public virtual IEnumerator<string> Run(Bot bot)
        {
            while(true)
                yield return this.GetType().Name;
        }
    }
}
