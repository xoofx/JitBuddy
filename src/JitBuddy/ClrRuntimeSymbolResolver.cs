using Iced.Intel;
using Microsoft.Diagnostics.Runtime;

namespace JitBuddy
{
    internal class ClrRuntimeSymbolResolver : ISymbolResolver
    {
        private readonly ClrRuntime _runtime;

        public ClrRuntimeSymbolResolver(ClrRuntime runtime)
        {
            _runtime = runtime;
        }

        public bool TryGetSymbol(in Instruction instruction, int operand, int instructionOperand,
            ulong address, int addressSize, out SymbolResult symbol)
        {
            ClrMethod method = _runtime.GetMethodByInstructionPointer(address);

            if (method != null && !string.IsNullOrEmpty(method.Signature))
            {
                symbol = new SymbolResult(address, method.Signature);
                return true;
            }
            symbol = default;
            return false;
        }
    }
}