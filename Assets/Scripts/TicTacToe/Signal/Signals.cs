using UnityEngine;
using strange.extensions.signal.impl;
using strange.extensions.pool.api;

public class StartSignal : Signal{};
public class ClickedCellSignal : Signal<int>{ };
public class ChangeTurnSignal : Signal<bool,int>{ };
public class MessageSignal : Signal<string>{ };
public class EndgameSignal : Signal {};
public class DataReceivedSignal : Signal<bool, string> { };
public class ResetSignal : Signal {};
public class ResetCommandSignal : Signal { };