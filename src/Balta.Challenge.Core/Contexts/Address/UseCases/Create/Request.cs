using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Create;

public record Request(int Id, string State, string City);

