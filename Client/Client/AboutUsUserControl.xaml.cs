using System;
using System.Windows.Controls;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace Client
{
    /// <summary>
    /// Interaction logic for AboutUsUserControl.xaml
    /// </summary>
    public partial class AboutUsUserControl : UserControl
    {
        public AboutUsUserControl()
        {
            InitializeComponent();
            ChuckNorrisJokeTB.Text = webRequests.WebRequestChuckNorris();
            DadJokeTB.Text = webRequests.WebRequestDadJoke();
            KanyeQuoteTB.Text = webRequests.WebRequestKanyeQuote();
            RandomJokesTB.Text = webRequests.WebRequestRandomJokes();
            InsultTB.Text = webRequests.WebRequestInsult();
            QuoteTB.Text = webRequests.WebRequestQuote();
            WhatDoesTrumpThinkTB.Text = webRequests.WebRequestWhatDoesTrumpThink();
            CatFactTB.Text = webRequests.WebRequestCatFact();
            ActivityTB.Text = webRequests.WebRequestActivity();
        }
    }
}
