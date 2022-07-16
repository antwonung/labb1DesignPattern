using System;
using System.Collections.Generic;
using System.Text;

namespace labb1DesignPattern.Factory
{
    public abstract class TitleFactory
    {
        //abstract class that declares the factory method, which returns an object of type
        public abstract ITitleFactory GetTitleClass(string title);
    }
}
