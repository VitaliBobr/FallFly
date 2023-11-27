using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public sealed class UnityTimer : IDisposable
{
    [SerializeField] private int _miliseconds = 0;
    [SerializeField] private UnityEvent _onEnd = new UnityEvent();

    private CancellationTokenSource tokenSource;
    private Task timerTask;

    public int Miliseconds => _miliseconds;

    public UnityTimer(int miliseconds, params UnityAction[] actions)
    {
        _miliseconds = miliseconds;

        if (actions != null || actions.Length != 0)
            for (int i = 0; i < actions.Length; i++)
                _onEnd.AddListener(actions[i]);

        tokenSource = new CancellationTokenSource();
        timerTask = Task.Run(async () => {
            do
            {
                if (tokenSource.IsCancellationRequested)
                    return;

                _miliseconds--;
                await Task.Delay(1);
            }
            while (_miliseconds != 0);

            _onEnd.Invoke();
        }, tokenSource.Token);
    }

    public void Dispose()
    {
        tokenSource?.Cancel();
        tokenSource?.Dispose();
        timerTask?.Dispose();
    }
}
