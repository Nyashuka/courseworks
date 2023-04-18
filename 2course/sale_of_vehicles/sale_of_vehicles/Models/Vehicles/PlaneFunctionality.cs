namespace sale_of_vehicles
{
    public class PlaneFunctionality : IFunctionality
    {
        public FunctionalyState LeftEngine { get; private set; }
        public FunctionalyState RightEngine { get; private set; }
        public FunctionalyState MainEngine { get; private set; }
        public FunctionalyState ControlSystem { get; private set; }

        public bool IsNormalFunctionality()
        {
            return LeftEngine == FunctionalyState.Good && RightEngine == FunctionalyState.Good &&
                   MainEngine == FunctionalyState.Good && ControlSystem == FunctionalyState.Good;
        }
    }
}
