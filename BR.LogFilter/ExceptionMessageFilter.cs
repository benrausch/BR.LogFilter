namespace BR.LogFilter
{
    using System;
    using log4net.Filter;
    using log4net.spi;

    public class ExceptionMessageFilter : FilterSkeleton
    {
        public string FilterValue { get; set; }

        public override FilterDecision Decide(LoggingEvent loggingEvent)
        {
            if (loggingEvent == null)
            {
                throw new ArgumentNullException("loggingEvent");
            }

            var loggingEventData = loggingEvent.GetLoggingEventData();
            if (loggingEventData.ExceptionString != null && loggingEventData.ExceptionString.Contains(FilterValue))
            {
                return FilterDecision.DENY;
            }

            return FilterDecision.NEUTRAL;
        }
    }
}

