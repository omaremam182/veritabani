﻿namespace veritabani
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));

            Routing.RegisterRoute("YapilacaklarPage", typeof(yapilacaklarPage));
        }
    }
}
