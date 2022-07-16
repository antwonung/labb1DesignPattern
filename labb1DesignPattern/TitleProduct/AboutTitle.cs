using System;
using System.Collections.Generic;
using System.Text;

namespace labb1DesignPattern.TitleProduct
{
    public class AboutTitle : ITitleFactory
    {
        //Class that implements title interface
        public string aboutTitle = @"
                 █████╗ ██████╗  ██████╗ ██╗   ██╗████████╗
                 ██╔══██╗██╔══██╗██╔═══██╗██║   ██║╚══██╔══╝
                 ███████║██████╔╝██║   ██║██║   ██║   ██║   
                 ██╔══██║██╔══██╗██║   ██║██║   ██║   ██║   
                 ██║  ██║██████╔╝╚██████╔╝╚██████╔╝   ██║   
                 ╚═╝  ╚═╝╚═════╝  ╚═════╝  ╚═════╝    ╚═╝   
                                           
             ";
        public string GetTitle()
        {
            return aboutTitle;
        }
    }
}
