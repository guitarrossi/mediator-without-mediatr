﻿using FluentValidation.Results;
using System.Collections.ObjectModel;

namespace MediatorWithoutMediatr.Commom
{
    public record Response
    {
        private readonly IList<ValidationFailure> _messages = new List<ValidationFailure>();

        public bool IsSuccess { get { return Errors.Count() == 0; } }
        public IEnumerable<ValidationFailure> Errors { get; }
        public object Result { get; }

        public Response() => Errors = new ReadOnlyCollection<ValidationFailure>(_messages);

        public Response(object result) : this() => Result = result;

        public Response AddError(ValidationFailure message)
        {
            _messages.Add(message);
            return this;
        }
    }
}
