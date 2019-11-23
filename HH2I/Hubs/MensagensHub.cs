namespace House2Invest.Hubs
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize]
    public class MensagensHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public MensagensHub(ApplicationDbContext context)
        {
            this._context = context;
        }

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

        [AsyncStateMachine((Type) typeof(<OnConnectedAsync>d__4))]
        public override Task OnConnectedAsync()
        {
            <OnConnectedAsync>d__4 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnConnectedAsync>d__4>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<OnDisconnectedAsync>d__5))]
        public override Task OnDisconnectedAsync(Exception exception)
        {
            <OnDisconnectedAsync>d__5 d__;
            d__.<>4__this = this;
            d__.exception = exception;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnDisconnectedAsync>d__5>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<Quem>d__6))]
        public Task Quem(string status)
        {
            <Quem>d__6 d__;
            d__.<>4__this = this;
            d__.status = status;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<Quem>d__6>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        private UsuarioApp RetornaUsuLogado(string uid)
        {
            <>c__DisplayClass2_0 class_;
            HubCallerContext _contextoConexao = base.get_Context();
            ParameterExpression expression = Expression.Parameter((Type) typeof(UsuarioApp), "x");
            Expression[] expressionArray1 = new Expression[] { (Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(<>c__DisplayClass2_0)), fieldof(<>c__DisplayClass2_0.uid)) };
            ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
            return Queryable.FirstOrDefault<UsuarioApp>(this._context.get_Users(), Expression.Lambda<Func<UsuarioApp, bool>>((Expression) Expression.Condition((Expression) Expression.Call(null, (MethodInfo) methodof(string.IsNullOrEmpty), expressionArray1), (Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(IdentityUser<string>.get_UserName, IdentityUser<string>)), (Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(<>c__DisplayClass2_0)), fieldof(<>c__DisplayClass2_0._contextoConexao)), (MethodInfo) methodof(HubCallerContext.get_User)), (MethodInfo) methodof(ClaimsPrincipal.get_Identity)), (MethodInfo) methodof(IIdentity.get_Name))), (Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(IdentityUser<string>.get_Id, IdentityUser<string>)), (Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(<>c__DisplayClass2_0)), fieldof(<>c__DisplayClass2_0.uid)))), expressionArray2));
        }

        private tblUsuSalaVIP RetornaUsuSalaVIP(string uid)
        {
            <>c__DisplayClass3_0 class_;
            HubCallerContext context = base.get_Context();
            ParameterExpression expression = Expression.Parameter((Type) typeof(tblUsuSalaVIP), "x");
            ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
            IIncludableQueryable<tblUsuSalaVIP, UsuarioApp> queryable1 = EntityFrameworkQueryableExtensions.Include<tblUsuSalaVIP, UsuarioApp>(this._context.tblUsuSalaVIPs, Expression.Lambda<Func<tblUsuSalaVIP, UsuarioApp>>((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(tblUsuSalaVIP.get_UsuarioApp)), expressionArray1));
            expression = Expression.Parameter((Type) typeof(tblUsuSalaVIP), "x");
            ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
            return Queryable.FirstOrDefault<tblUsuSalaVIP>(queryable1, Expression.Lambda<Func<tblUsuSalaVIP, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(tblUsuSalaVIP.get_UsuarioAppId)), (Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(<>c__DisplayClass3_0)), fieldof(<>c__DisplayClass3_0.uid))), expressionArray2));
        }

        [AsyncStateMachine((Type) typeof(<Teclando>d__7))]
        public Task Teclando(string de, string para)
        {
            <Teclando>d__7 d__;
            d__.<>4__this = this;
            d__.para = para;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<Teclando>d__7>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly MensagensHub.<>c <>9 = new MensagensHub.<>c();
        }

        [CompilerGenerated]
        private struct <OnConnectedAsync>d__4 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public MensagensHub <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                MensagensHub hub = this.<>4__this;
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
                        awaiter = hub.Quem("ENTROU").GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MensagensHub.<OnConnectedAsync>d__4>(ref awaiter, ref this);
                            return;
                        }
                    }
                    awaiter.GetResult();
                    awaiter2 = hub.<>n__0().GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__1 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MensagensHub.<OnConnectedAsync>d__4>(ref awaiter2, ref this);
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
        private struct <OnDisconnectedAsync>d__5 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public MensagensHub <>4__this;
            public Exception exception;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                MensagensHub hub = this.<>4__this;
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
                        awaiter = hub.Quem("SAIU").GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MensagensHub.<OnDisconnectedAsync>d__5>(ref awaiter, ref this);
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
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MensagensHub.<OnDisconnectedAsync>d__5>(ref awaiter2, ref this);
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
        private struct <Quem>d__6 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public MensagensHub <>4__this;
            private MensagensHub.<>c__DisplayClass6_0 <>8__1;
            public string status;
            private HubCallerContext <_contextoConexao>5__2;
            private TaskAwaiter<tblUsuSalaVIP> <>u__1;
            private TaskAwaiter<int> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                int num = this.<>1__state;
                MensagensHub hub = this.<>4__this;
                try
                {
                    int num2 = num;
                    try
                    {
                        TaskAwaiter<tblUsuSalaVIP> awaiter;
                        CancellationToken token;
                        TaskAwaiter<int> awaiter2;
                        TaskAwaiter<int> awaiter3;
                        TaskAwaiter awaiter4;
                        switch (num)
                        {
                            case 0:
                                awaiter = this.<>u__1;
                                this.<>u__1 = new TaskAwaiter<tblUsuSalaVIP>();
                                this.<>1__state = num = -1;
                                break;

                            case 1:
                                awaiter2 = this.<>u__2;
                                this.<>u__2 = new TaskAwaiter<int>();
                                this.<>1__state = num = -1;
                                goto TR_000A;

                            case 2:
                                awaiter3 = this.<>u__2;
                                this.<>u__2 = new TaskAwaiter<int>();
                                this.<>1__state = num = -1;
                                goto TR_000E;

                            case 3:
                                awaiter4 = this.<>u__3;
                                this.<>u__3 = new TaskAwaiter();
                                this.<>1__state = num = -1;
                                goto TR_0007;

                            default:
                            {
                                this.<>8__1 = new MensagensHub.<>c__DisplayClass6_0();
                                this.<>8__1._quem = hub.RetornaUsuLogado("");
                                this.<_contextoConexao>5__2 = hub.get_Context();
                                ParameterExpression expression = Expression.Parameter((Type) typeof(tblUsuSalaVIP), "x");
                                ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
                                token = new CancellationToken();
                                awaiter = EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<tblUsuSalaVIP>(hub._context.tblUsuSalaVIPs, Expression.Lambda<Func<tblUsuSalaVIP, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(tblUsuSalaVIP.get_UsuarioAppId)), (Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant(this.<>8__1, (Type) typeof(MensagensHub.<>c__DisplayClass6_0)), fieldof(MensagensHub.<>c__DisplayClass6_0._quem)), (MethodInfo) methodof(IdentityUser<string>.get_Id, IdentityUser<string>))), expressionArray1), token).GetAwaiter();
                                if (awaiter.IsCompleted)
                                {
                                    break;
                                }
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<tblUsuSalaVIP>, MensagensHub.<Quem>d__6>(ref awaiter, ref this);
                                return;
                            }
                        }
                        tblUsuSalaVIP result = awaiter.GetResult();
                        if (result != null)
                        {
                            result.DTHR = DateTime.get_Now();
                            result.CnxId = this.<_contextoConexao>5__2.get_ConnectionId();
                            result.Status = this.status;
                            hub._context.Attach<tblUsuSalaVIP>(result).set_State(3);
                            token = new CancellationToken();
                            awaiter3 = hub._context.SaveChangesAsync(token).GetAwaiter();
                            if (awaiter3.IsCompleted)
                            {
                                goto TR_000E;
                            }
                            else
                            {
                                this.<>1__state = num = 2;
                                this.<>u__2 = awaiter3;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, MensagensHub.<Quem>d__6>(ref awaiter3, ref this);
                            }
                        }
                        else
                        {
                            tblUsuSalaVIP avip1 = new tblUsuSalaVIP();
                            avip1.CnxId = this.<_contextoConexao>5__2.get_ConnectionId();
                            avip1.UsuarioAppId = this.<>8__1._quem.get_Id();
                            avip1.Status = this.status;
                            tblUsuSalaVIP avip3 = avip1;
                            hub._context.tblUsuSalaVIPs.Add(avip3);
                            token = new CancellationToken();
                            awaiter2 = hub._context.SaveChangesAsync(token).GetAwaiter();
                            if (awaiter2.IsCompleted)
                            {
                                goto TR_000A;
                            }
                            else
                            {
                                this.<>1__state = num = 1;
                                this.<>u__2 = awaiter2;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, MensagensHub.<Quem>d__6>(ref awaiter2, ref this);
                            }
                        }
                        return;
                    TR_0007:
                        awaiter4.GetResult();
                        this.<>8__1 = null;
                        this.<_contextoConexao>5__2 = null;
                        goto TR_0002;
                    TR_0008:
                        token = new CancellationToken();
                        awaiter4 = ClientProxyExtensions.SendAsync(hub.get_Clients().get_All(), "quem", this.<_contextoConexao>5__2.get_ConnectionId(), this.<>8__1._quem.get_Id(), this.<>8__1._quem.Nome + " " + this.<>8__1._quem.Sobrenome, this.status, token).GetAwaiter();
                        if (awaiter4.IsCompleted)
                        {
                            goto TR_0007;
                        }
                        else
                        {
                            this.<>1__state = num = 3;
                            this.<>u__3 = awaiter4;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MensagensHub.<Quem>d__6>(ref awaiter4, ref this);
                        }
                        return;
                    TR_000A:
                        awaiter2.GetResult();
                        goto TR_0008;
                    TR_000E:
                        awaiter3.GetResult();
                        goto TR_0008;
                    }
                    catch (Exception exception1)
                    {
                        string message = exception1.Message;
                    }
                }
                catch (Exception exception2)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception2);
                    return;
                }
            TR_0002:
                this.<>1__state = -2;
                this.<>t__builder.SetResult();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <Teclando>d__7 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public MensagensHub <>4__this;
            public string para;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                MensagensHub hub = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                    }
                    else
                    {
                        UsuarioApp app = hub.RetornaUsuLogado("");
                        tblUsuSalaVIP avip = hub.RetornaUsuSalaVIP(this.para);
                        if (app == null)
                        {
                            goto TR_0003;
                        }
                        else if (avip == null)
                        {
                            goto TR_0003;
                        }
                        else
                        {
                            CancellationToken token = new CancellationToken();
                            awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().Client(avip.CnxId), "teclando", app.Nome + " " + app.Sobrenome, avip.UsuarioApp.Nome + " " + avip.UsuarioApp.Sobrenome, app.get_Id(), avip.UsuarioAppId, token).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto TR_0004;
                            }
                            else
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, MensagensHub.<Teclando>d__7>(ref awaiter, ref this);
                            }
                        }
                        return;
                    }
                TR_0004:
                    awaiter.GetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            TR_0003:
                this.<>1__state = -2;
                this.<>t__builder.SetResult();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }
    }
}

