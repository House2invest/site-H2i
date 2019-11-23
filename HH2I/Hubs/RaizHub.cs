namespace House2Invest.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class RaizHub : Hub
    {
        public static HashSet<string> CurrentConnections = new HashSet<string>();

        [CompilerGenerated, DebuggerHidden]
        private Task <>n__0()
        {
            return base.OnConnectedAsync();
        }

        [CompilerGenerated, DebuggerHidden]
        private Task <>n__1(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        [AsyncStateMachine((Type) typeof(<ClientConnected>d__7))]
        public void ClientConnected(string connectionId)
        {
            <ClientConnected>d__7 d__;
            d__.<>4__this = this;
            d__.connectionId = connectionId;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<ClientConnected>d__7>(ref d__);
        }

        public string GetConnectionId()
        {
            return base.get_Context().get_ConnectionId();
        }

        [AsyncStateMachine((Type) typeof(<GravaLog>d__3))]
        public Task GravaLog(string idusu, string idcnx, string status)
        {
            <GravaLog>d__3 d__;
            d__.<>4__this = this;
            d__.idusu = idusu;
            d__.idcnx = idcnx;
            d__.status = status;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<GravaLog>d__3>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        public List<string> ListaUsuariosAtivos()
        {
            return this.RetornaConexoesAtivas();
        }

        [AsyncStateMachine((Type) typeof(<OnConnectedAsync>d__1))]
        public override Task OnConnectedAsync()
        {
            <OnConnectedAsync>d__1 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnConnectedAsync>d__1>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<OnDisconnectedAsync>d__2))]
        public override Task OnDisconnectedAsync(Exception exception)
        {
            <OnDisconnectedAsync>d__2 d__;
            d__.<>4__this = this;
            d__.exception = exception;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnDisconnectedAsync>d__2>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        public void OrientationChanged(string connectionId, OrientationData orientationData)
        {
        }

        public List<string> RetornaConexoesAtivas()
        {
            return Enumerable.ToList<string>((IEnumerable<string>) CurrentConnections);
        }

        [AsyncStateMachine((Type) typeof(<StartExecution>d__8))]
        public void StartExecution(string connectionId)
        {
            <StartExecution>d__8 d__;
            d__.<>4__this = this;
            d__.connectionId = connectionId;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<StartExecution>d__8>(ref d__);
        }

        [CompilerGenerated]
        private struct <ClientConnected>d__7 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public RaizHub <>4__this;
            public string connectionId;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                RaizHub hub = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        string str = hub.get_Context().get_ConnectionId();
                        CancellationToken token = new CancellationToken();
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().get_All(), "GravaLog", "visitante", this.connectionId, "CONECTADO", token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, RaizHub.<ClientConnected>d__7>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    awaiter.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <GravaLog>d__3 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public RaizHub <>4__this;
            public string idusu;
            public string idcnx;
            public string status;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                RaizHub hub = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        CancellationToken token = new CancellationToken();
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().get_All(), "GravaLog", this.idusu, this.idcnx, this.status, token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, RaizHub.<GravaLog>d__3>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    awaiter.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <OnConnectedAsync>d__1 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public RaizHub <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                RaizHub hub = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        string item = hub.get_Context().get_ConnectionId();
                        RaizHub.CurrentConnections.Add(item);
                        hub.ClientConnected(item);
                        awaiter = hub.<>n__0().GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, RaizHub.<OnConnectedAsync>d__1>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    awaiter.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <OnDisconnectedAsync>d__2 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public RaizHub <>4__this;
            public Exception exception;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                RaizHub hub = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    TaskAwaiter awaiter2;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                    }
                    else if (num == 1)
                    {
                        awaiter2 = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0005;
                    }
                    else
                    {
                        string item = Enumerable.FirstOrDefault<string>((IEnumerable<string>) RaizHub.CurrentConnections, new Func<string, bool>(hub.<OnDisconnectedAsync>b__2_0));
                        if (item != null)
                        {
                            RaizHub.CurrentConnections.Remove(item);
                        }
                        CancellationToken token = new CancellationToken();
                        awaiter = hub.get_Groups().RemoveFromGroupAsync(hub.get_Context().get_ConnectionId(), "SignalR Users", token).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, RaizHub.<OnDisconnectedAsync>d__2>(ref awaiter, ref this);
                            return;
                        }
                    }
                    awaiter.GetResult();
                    awaiter2 = hub.<>n__1(this.exception).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__1 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, RaizHub.<OnDisconnectedAsync>d__2>(ref awaiter2, ref this);
                    }
                    return;
                TR_0005:
                    awaiter2.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <StartExecution>d__8 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public RaizHub <>4__this;
            public string connectionId;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                RaizHub hub = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        CancellationToken token = new CancellationToken();
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().get_All(), "GravaLog", "visitante", this.connectionId, "EXECUCAO INICIADA", token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, RaizHub.<StartExecution>d__8>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    awaiter.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }
    }
}

