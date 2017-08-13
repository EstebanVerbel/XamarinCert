using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {

        static readonly Lazy<QuoteManager> _instance = new Lazy<QuoteManager>(() => new QuoteManager());
        public static QuoteManager Instance { get { return _instance.Value; } }

        readonly IQuoteLoader _repo;
        public IList<GreatQuote> Quotes { get; private set; }

        // the constructor is private because we're using the singleton pattern
        private QuoteManager()
        {
            _repo = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuote>(_repo.Load());
        }

        public void Save()
        {
            _repo.Save(Quotes);
        }

        public void SayQuote(GreatQuote quote)
        {
            if (quote == null)
                throw new ArgumentException("Quote is Null (TextToSpeech)");

            var textToSpeechService = ServiceLocator.Instance.Resolve<ITextToSpeech>();

            if (textToSpeechService != null)
            {
                string text = quote.QuoteText;
                
                if (!string.IsNullOrEmpty(quote.Author))
                    text += $" by {quote.Author}";

                textToSpeechService.Speak(text);
            }
        }

    }
}
