namespace sale_of_vehicles
{
    public class CarFunctionality : IFunctionality
    {
        public FunctionalyState WheelsState { get; private set; }
        public FunctionalyState EngineState { get; private set; }
        
        public bool IsNormalFunctionality()
        {
            return (WheelsState == FunctionalyState.Normal || WheelsState == FunctionalyState.Good) && 
                    EngineState == FunctionalyState.Good;
        }
    }
}
