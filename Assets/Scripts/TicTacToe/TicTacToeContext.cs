using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class TicTacToeContext : MVCSContext
{
    public TicTacToeContext(MonoBehaviour contextView) : base(contextView) { }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        injectionBinder.Bind<ICellModel>().To<CellModel>();
        injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();

        injectionBinder.Bind<ChangeTurnSignal>().ToSingleton();
        injectionBinder.Bind<MessageSignal>().ToSingleton();
        injectionBinder.Bind<EndgameSignal>().ToSingleton();
        injectionBinder.Bind<ResetSignal>().ToSingleton();
        injectionBinder.Bind<DataReceivedSignal>().ToSingleton();

        mediationBinder.Bind<PlayAgainView>().To<PlayAgainViewMediator>();
        mediationBinder.Bind<TurnView>().To<TurnViewMediator>();
        mediationBinder.Bind<StatusView>().To<StatusViewMediator>();
        mediationBinder.Bind<CellView>().To<CellViewMediator>();

        commandBinder.Bind<StartSignal>().To<StartGameCommand>().Once();
        commandBinder.Bind<ResetCommandSignal>().To<ResetGameCommand>();
        commandBinder.Bind<ClickedCellSignal>().To<SelectCellCommand>();

    }

    public override void Launch()
    {
        base.Launch();
        StartSignal startSignal = injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
    }

}
