using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JiahuScriptRuntime.Exceptions.Compiler;
using JiahuScriptRuntime.External.Attributes;

namespace JiahuScriptRuntime.External
{
    public abstract class FunctionBase : IFunction
    {
        private const string Dot = ".";

        private readonly List<IFunctionDefinition> _definitions = new List<IFunctionDefinition>();
        private readonly List<IParameter> _parameters = new List<IParameter>();
        private ReturnTypeAttribute _returnTypeAttribute;

        public List<IFunctionDefinition> Definitions { get { return _definitions; } }
        public List<IParameter> Parameters { get { return _parameters; } }
        public IReturnType ReturnType { get { return _returnTypeAttribute; } }

        protected FunctionBase()
        {
            SetupParametersTypes();
        }

        public virtual object Eval(string functionName, object[] parameters)
        {
            throw new NotImplementedException("Eval not implemented.");
        }

        protected void CheckParametersAndThrowOnMissMatch(object[] parameters)
        {
            int parametersLength = parameters != null ? parameters.Length : 0;

            if (parametersLength < Parameters.Count(x => !x.Optional) || parametersLength > Parameters.Count)
            {
                throw new FunctionParameterCountException(GetSafeFunctionName());
            }

            int index = 0;
            foreach (IParameter parameter in Parameters.OrderBy(x => x.Order))
            {
                if ((!parameter.Optional || parametersLength > index) && !parameter.IgnoreTypeCheck)
                {
                    if (parameters[index].GetType() != parameter.Type)
                    {
                        throw new InvalidFunctionParameterException(GetSafeFunctionName(), parameter.Name);
                    }
                }
                index++;
            }
        }

        private void SetupParametersTypes()
        {
            _definitions.AddRange(GetType().GetCustomAttributes<FunctionAttribute>());
            if (_definitions.Count == 0)
            {
                throw new ArgumentNullException(string.Format("Function object {0} has no FunctionAttribute.", GetType().Name));
            }

            _returnTypeAttribute = GetType().GetCustomAttribute<ReturnTypeAttribute>();
            if (_returnTypeAttribute == null)
            {
                throw new ArgumentNullException(string.Format("Function object {0} has no ReturnTypeAttribute.", GetType().Name));
            }

            _parameters.AddRange(GetType().GetCustomAttributes<ParameterAttribute>().OrderBy(x => x.Order)); 
        }

        private string GetSafeFunctionName()
        {
            return Definitions.Count >= 1 ? Definitions[0].Name : GetType().Name;
        }

        protected string GetFunctionNameWithoutTag(string functionName)
        {
            return functionName.Contains(Dot) ? functionName.Substring(functionName.LastIndexOf(Dot, StringComparison.Ordinal) + 1, (functionName.Length - functionName.LastIndexOf(Dot, StringComparison.Ordinal)) -1) : functionName;
        }
    }
}