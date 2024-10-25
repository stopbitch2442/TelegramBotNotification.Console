using System;
using System.Threading.Tasks;
using WTelegram;

public enum Commands
{
    SendMessage = 1,
    SomeSendMessage,
    SendScheduleMessage,
    SomeSendScheduleMessage
}

public class CommandList
{
    public static async Task ShowCommandList(Client client)
    {
        await Console.Out.WriteLineAsync("Введите номер команды, которую необходимо выполнить:");
        
        foreach (Commands command in Enum.GetValues(typeof(Commands)))
        {
            await Console.Out.WriteLineAsync($"{(int)command} - {command}");
        }

        string strChoice = await Console.In.ReadLineAsync();
        
        if (int.TryParse(strChoice, out int choice) && Enum.IsDefined(typeof(Commands), choice))
        {
            switch ((Commands)choice)
            {
                case Commands.SendMessage:
                    await NowSendMessage.SendMessage(client);
                    break;
                case Commands.SomeSendMessage:
                    await NowSendMessage.SomeSendMessage(client);
                    break;
                case Commands.SendScheduleMessage:
                    await ScheduleMessage.SendScheduleMessage(client);
                    break;
                case Commands.SomeSendScheduleMessage:
                    await ScheduleMessage.SomeSendScheduleMessage(client);
                    break;
            }
        }
        else
        {
            await Console.Out.WriteLineAsync("Ввели неправильное значение. Попробуйте снова.");
            await ShowCommandList(client);
        }
    }
}