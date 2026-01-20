namespace Pelebox.API.Extension {
    public class NotFoundException : Exception {
        public NotFoundException(string message) : base(message) { }
    }

    public class ValidationException : Exception {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IDictionary<string, string[]> errors)
            : base("Validation failed") {
            Errors = errors;
        }
    }

    public class BusinessRuleException : Exception {
        public string RuleCode { get; }

        public BusinessRuleException(string message, string ruleCode)
            : base(message) {
            RuleCode = ruleCode;
        }
    }
}
