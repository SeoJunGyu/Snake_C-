using Snake;

Console.CursorVisible = false;
bool isStart = false;
int score = 1;
ConsoleKeyInfo input = new ConsoleKeyInfo();

Map m = new Map();
SnakeBody snake = new SnakeBody();
m.InitMap();
snake.InitBody(m);
Feed.MakeFeed(m);

while (true)
{
    while(!isStart)
    {
        if(Console.KeyAvailable)
        {
            input = Console.ReadKey(true);
            if(input.Key == ConsoleKey.Spacebar)
            {
                isStart = true;
                Console.Clear();
                break;
            }
        }
        Console.WriteLine("스네이크 게임\nSPACE 키를 눌러서 시작하세요!");
        //System.Threading.Thread.Sleep(300); // 대기
        //Console.Clear();
        Console.SetCursorPosition(0, 0);
    }

    System.Threading.Thread.Sleep(300); // 대기
    Console.SetCursorPosition(0, 0);
    
    snake.MoveBody(m);
    if(snake.GameOver(m, snake.index))
    {
        Console.Clear();
        while (isStart)
        {
            Console.WriteLine($"게임 오버! 점수 : {score}\n 재시작은 Space");
            if (Console.KeyAvailable)
            {
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Spacebar)
                {
                    m.InitMap();
                    snake.InitBody(m);
                    Feed.MakeFeed(m);
                    score = 0;
                    isStart = false;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
        Console.Clear();
        continue;
    }
    if(snake.col == Feed.col && snake.row == Feed.row)
    {
        Feed.MakeFeed(m);
        //snake.AddBody(m);
        score++;
    }
    m.ShowMap();

    Console.WriteLine($"\n점수 : {score}");
}
