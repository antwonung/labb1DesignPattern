using labb1DesignPattern.TitleProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace labb1DesignPattern.Factory
{
    public class ConcreteTitleFactory : TitleFactory
    {
        //Class which implements the Creator class and overrides the factory method to return an instance of a TitleProduct
        public override ITitleFactory GetTitleClass(string title)
        {
            switch (title)
            {
                case "AboutTitle":
                    return new AboutTitle();
                case "MenuTitle":
                    return new MenuTitle();
                default:
                    throw new NotImplementedException(string.Format("title {0}' cannot be created", title))
                    {
                    };
            }
        
        }

    }
}
