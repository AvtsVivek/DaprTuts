var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');

var indexRouter = require('./routes/index');
var usersRouter = require('./routes/users');

var app = express();

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', indexRouter);
app.use('/users', usersRouter);

// https://youtu.be/OtbYCBt9C34?t=662
// Publishing an event through dapr and recieve that in our application.
// setting up the infrastructure that will tell dapr about the events that we are instrrested in.

// The following is what the dapr runtime will call when the application starts, 
// so it knows what topics you are intrested in. So here we are intrested in topicA
app.get('/dapr/subscribe', function(req, res, next){
  res.json(['topicA']);
});

// https://youtu.be/OtbYCBt9C34?t=753
// This is the endpoint that is called by dapr, when dapr recieves an event through 
// dapr event binding mechanism
// The messageing endpoint is not working.
// Enter the publish subscribe component name used to publish dapr. I entered pubsub.
// But the following endpoint is not hit.
app.post('/topicA', express.json({type: 'application/cloudevents+json'}), function(req, res, next){
  res.sendStatus(200);
});

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

const port = 3001;
app.listen(port, () => console.log(`Node App listening on port ${port}!`));

module.exports = app;
