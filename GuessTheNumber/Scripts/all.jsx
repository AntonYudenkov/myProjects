class TodoApp extends React.Component {
  constructor(props) {
    super(props);
    this.state = { items: [], text: '', secretnumber: '', msg: '', msgres: ''};
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.SecretSubmit = this.SecretSubmit.bind(this);
  }

  render() {
    return (
      <div>
        <h3>Угадай число</h3>
          <form onSubmit={this.SecretSubmit}>
          <label id="lbl" htmlFor="secret-todo">
              {this.state.msg}
          </label>
              <br/>
          <button>
              Загадать число
          </button>
        </form>
        <br /><br />
        <TodoList items={this.state.items} />
        <form onSubmit={this.handleSubmit}>
          <label htmlFor="new-todo">
              Введите число от 0 до 9999 
          </label>
              <br />
          <input id="new-todo" 
                 onChange={this.handleChange}
                 value={this.state.text} />
          <button>
              Проверить число
          </button>
          <br /><br />
          <label id="lbl2" htmlFor="new-todo">
           {this.state.msgres}
          </label>
        </form>
      </div>
    );
  }



  SecretSubmit(e) {
    e.preventDefault();
            $.ajax({
                url: '/Home/GetSecret',
                context: this,
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                type: 'GET',
                data: {},
                success: function(result) {
                      this.setState(state => ({                        
                          secretnumber: result
                        }));
                }
            });

  this.setState(state => ({
                          msg: 'Число загадано'
                        }));
}

  handleChange(e) {
    const re = /^[0-9\b]+$/;
 if (e.target.value === '' || re.test(e.target.value)) {
    this.setState({ text: e.target.value });
   }
  }

  handleSubmit(e) {
    e.preventDefault();

    if (!this.state.secretnumber.length) {
     this.setState(state => ({
     msgres: 'Число не загадано!!! Нажмите загадать число!!!'
                        }));
      return;
    }

    if (!this.state.text.length) {
      return;
    }

    if (this.state.text.length > 4) {
     this.setState(state => ({
      msgres: 'Число должно быть не более 9999'
                        }));
      return;
    } 

  const newItem = {
      text: this.state.text,
      id: Date.now()
    };
    this.setState(state => ({
      items: state.items.concat(newItem),
      text: ''
    }));

var r = '';
 $.ajax({
                url: '/Home/CheckSecret',
                context: this,
                datatype: 'json',
                contentType: 'application/json; charset=utf-8',
                type: 'GET',
                data: {
vle: this.state.text,
secret: this.state.secretnumber},
                success: function(result) {
                    this.setState(state => ({
                          msgres: 'Результат: ' + result
                        }));
                }
            }); 
  }
}

class TodoList extends React.Component {
  render() {
    return (
      <ul>
          {this.props.items.map(item => (
          <li key={item.id}>{item.text}</li>
          ))}
      </ul>
    );
  }
}

ReactDOM.render(<TodoApp />, document.getElementById("content"));


