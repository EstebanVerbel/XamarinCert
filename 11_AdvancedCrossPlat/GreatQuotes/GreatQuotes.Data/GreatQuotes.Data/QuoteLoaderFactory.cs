﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatQuotes.Data
{
    public static class QuoteLoaderFactory
    {
        
        public static Func<IQuoteLoader> Create { get; set; }

    }
}
