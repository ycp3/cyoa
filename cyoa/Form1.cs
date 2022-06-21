namespace cyoa;

public partial class Form1 : Form
{
    private Label _textBox;
    private Button _button1;
    private Button _button2;
    private Button _button3;
    private Button _backButton;
    private Button _resetButton;
    private PictureBox _pictureBox;
    
    public Form1()
    {
        InitializeComponent();
        Initialize();

        Cyoa guide = new Cyoa(_button1, _button2, _button3, _backButton, _resetButton, _textBox, _pictureBox);
        guide.Start();
    }

    private void Initialize()
    {
        Height = 1080;
        Width = 1920;
        
        _button1 = new Button();
        _button1.Size = new Size(ClientSize.Width / 3, ClientSize.Height / 5);
        _button1.Location = new Point(0, ClientSize.Height - _button1.Height);
        _button2 = new Button();
        _button2.Size = new Size(ClientSize.Width / 3, ClientSize.Height / 5);
        _button2.Location = new Point(_button1.Width, ClientSize.Height - _button1.Height);
        _button3 = new Button();
        _button3.Size = new Size(ClientSize.Width / 3, ClientSize.Height / 5);
        _button3.Location = new Point(_button1.Width * 2, ClientSize.Height - _button1.Height);

        var font = new Font(_button1.Font.Name, 20);
        _button1.Font = font;
        _button2.Font = font;
        _button3.Font = font;
        
        _textBox = new Label();
        _textBox.TextAlign = ContentAlignment.BottomCenter;
        _textBox.Font = new Font(font.Name, 15);
        
        _pictureBox = new PictureBox();
        _pictureBox.Size = new Size(ClientSize.Width, (ClientSize.Height - _button1.Height) / 2);
        _pictureBox.Location = new Point(0, (ClientSize.Height - _button1.Height) / 2);

        _backButton = new Button();
        _backButton.Text = "Back";
        _backButton.Size = new Size(_backButton.Width, _backButton.Height + 10);
        _textBox.Location = new Point(0, _backButton.Height);
        _textBox.Size = new Size(ClientSize.Width, _pictureBox.Location.Y - _backButton.Height);

        _resetButton = new Button();
        _resetButton.Text = "Reset";
        _resetButton.Size = _backButton.Size;
        _resetButton.Location = new Point(_backButton.Width, 0);

        Controls.Add(_backButton);
        Controls.Add(_resetButton);
        Controls.Add(_pictureBox);
        Controls.Add(_button1);
        Controls.Add(_button2);
        Controls.Add(_button3);
        Controls.Add(_textBox);
    }
}