using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CQRS
{
	public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand>
	{
	}
}
