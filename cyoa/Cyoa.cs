namespace cyoa;

public class Cyoa
{
    private int _index;
    private Button _button1;
    private Button _button2;
    private Button _button3;
    private Button _backButton;
    private Button _resetButton;
    private Label _textBox;
    private PictureBox _pictureBox;

    private class Scene
    {
        public string text;
        public string option1;
        public int index1;
        public string option2;
        public int index2;
        public string option3;
        public int index3;
        public bool gameover;
    }

    private List<Scene> _scenes;
    private List<int> _history;
    private Scene _currentScene;

    public Cyoa(Button button1, Button button2, Button button3, Button backButton, Button resetButton, Label textBox, PictureBox pictureBox)
    {
        _index = 0;
        _scenes = new List<Scene>();
        _history = new List<int>();
        
        _button1 = button1;
        _button2 = button2;
        _button3 = button3;
        _backButton = backButton;
        _resetButton = resetButton;
        _textBox = textBox;
        _pictureBox = pictureBox;

        _button1.Click += button1_Click;
        _button2.Click += button2_Click;
        _button3.Click += button3_Click;
        _backButton.Click += backButton_Click;
        _resetButton.Click += resetButton_Click;

        _scenes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Scene>>(
            File.ReadAllText(@"C:\Users\Jasper\RiderProjects\cyoa\cyoa\scenes.json"))!;
    }

    public void Start()
    {
        Update();
    }

    private void Update()
    {
        _currentScene = _scenes[_index];
        _history.Add(_index);
        _textBox.Text = _currentScene.text;
        _button1.Text = _currentScene.option1;
        _button2.Text = _currentScene.option2;
        _button3.Text = _currentScene.option3;
        _pictureBox.Load(@"C:\Users\Jasper\RiderProjects\cyoa\cyoa\images\" + _index + ".png");

        if (_currentScene.gameover)
        {
            _button1.Visible = false;
            _button2.Visible = false;
            _button3.Visible = false;
        }
        else
        {
            _button1.Visible = true;
            _button2.Visible = true;
            _button3.Visible = true;
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        _index = _currentScene.index1;
        Update();
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        _index = _currentScene.index2;
        Update();
    }
    
    private void button3_Click(object sender, EventArgs e)
    {
        _index = _currentScene.index3;
        Update();
    }

    private void backButton_Click(object sender, EventArgs e)
    {
        if (_history.Count > 1)
        {
            _history.RemoveAt(_history.Count - 1);
            _index = _history[^1];
            _history.RemoveAt(_history.Count - 1);
            Update();
        }
    }

    private void resetButton_Click(object sender, EventArgs e)
    {
        _history.Clear();
        _index = 0;
        Update();
    }
}
