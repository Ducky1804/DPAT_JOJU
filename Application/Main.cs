using DPAT_JOJU.Commands;
using Model;

namespace DPAT_JOJU;

class Application
{
    private static String fileContent =
        "# Timed light\r\n# This file contains an example FSM\r\n\r\n#\r\n# Description of all the states\r\n#\r\n\r\nSTATE initial _ \"powered off\" : INITIAL;\r\nSTATE powered _ \"Powered up\" : COMPOUND;\r\nSTATE off powered \"Lamp is off\" : SIMPLE;\r\nSTATE on powered \"Lamp is on\" : SIMPLE;\r\nSTATE final _ \"powered off\" : FINAL;\r\n\r\n#\r\n# Description of all the triggers\r\n#\r\n\r\nTRIGGER power_on \"turn power on\";\r\nTRIGGER push_switch \"Push switch\";\r\nTRIGGER power_off \"turn power off\";\r\n\r\n#\r\n# Description of all the actions\r\n#\r\n\r\nACTION on \"Turn lamp on\" : ENTRY_ACTION;\r\nACTION on \"Turn lamp off\" : EXIT_ACTION;\r\nACTION off \"Start off timer\" : ENTRY_ACTION;\r\nACTION t2 \"reset off timer\" : TRANSITION_ACTION;\r\n\r\n#\r\n# Description of all the transitions\r\n#\r\n\r\nTRANSITION t1 initial -> off power_on \"\";\r\nTRANSITION t2 off -> on push_switch \"time off > 10s\";\r\nTRANSITION t3 on -> off push_switch \"\";\r\nTRANSITION t4 powered -> final power_off \"\";\r\n";
    
    public static void Main(string[] args)
    {
        ICommand<Diagram> loadCommand = new LoadCommand(fileContent);
        Diagram diagram = loadCommand.Execute();
        
        ICommand<Boolean> validateCommand = new ValidateCommand(diagram);
        Boolean valid = validateCommand.Execute();
        
        ICommand<Boolean> viewCommand = new ViewCommand(diagram);
        Boolean view =  viewCommand.Execute();
    }
}