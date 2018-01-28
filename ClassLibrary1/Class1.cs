using DryIoc;

namespace ClassLibrary1
{
    public class Class1
    {

        IContainer GetContainerWithRegistrations()
        {
            var container = new Container();

            // NOTE: `RegisterDelegate` and `UseInstance` are not supported because of runtime state usage.
            // Instead you can use `RegisterPlaceholder` to fix object graph generation, then fill in
            // placeholder using run-time `DryIocZero.RegisterDelegate` and `DryIocZero.UseInstance`

            // TODO: Add registrations
            // container.Register<IMyServive, MyService>();

            container.Register<IMyService, MyService>(reuse: Reuse.Singleton, setup: Setup.With(asResolutionRoot: true));

            return container;
        }

    }
}
