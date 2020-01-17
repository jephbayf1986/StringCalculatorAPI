using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Application.Operations
{
    public interface IOperation
    {
        decimal Perform();
    }
}