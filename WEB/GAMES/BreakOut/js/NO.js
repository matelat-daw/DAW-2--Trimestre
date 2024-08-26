const grid = document.querySelector('.grid');
// const scoreDisplay = document.querySelector('#score');
const scoreDisplay = document.getElementById('score');
const blockWidth = 100;
const blockHeight = 20;
const ballDiameter = 20;
const boardWidth = 1024;
const boardHeight = 768;
let xDirection = -4;
let yDirection = 4;

const userStart = [230, 10];
let currentPosition = userStart;

const ballStart = [270, 40];
let ballCurrentPosition = ballStart;

let timerId;
let score = 0;

//my block
// class Block {
//   constructor(xAxis, yAxis) {
//     this.topLeft = [xAxis, yAxis];
//     this.topRight = [xAxis + blockWidth, yAxis];
//     this.bottomLeft = [xAxis, yAxis - blockHeight];
//     this.bottomRight = [xAxis + blockWidth, yAxis - blockHeight];
//   }
// }

// //all my blocks
// const blocks = [
//   new Block(10, 270),
//   new Block(120, 270),
//   new Block(230, 270),
//   new Block(340, 270),
//   new Block(450, 270),
//   new Block(10, 240),
//   new Block(120, 240),
//   new Block(230, 240),
//   new Block(340, 240),
//   new Block(450, 240),
//   new Block(10, 210),
//   new Block(120, 210),
//   new Block(230, 210),
//   new Block(340, 210),
//   new Block(450, 210),
// ]

//draw my blocks
function addBlocks() {
    let block = [];
  for (let i = 0; i < 10; i++) {
    block[i] = document.createElement('div');
    block[i].classList.add('block');
    // block[i].style.marginLeft = 20 * i + 'px';
    switch (i)
    {
        case 0:
        case 4:
        case 8:
            block[i].style.backgroundColor = 'red';
            break;
        case 1:
        case 5:
        case 9:
            block[i].style.backgroundColor = 'green';
            break;
        case 2:
        case 6:
            block[i].style.backgroundColor = 'blue';
            break;
        default:
            block[i].style.backgroundColor = 'yellow';
    }
    block[i].id = i;
    block[i].style.top = 40 + 'px';
    block[i].style.left = 20 + (i * 100) + 'px';
    grid.appendChild(block[i]);
  }
}
addBlocks()

//add user
const user = document.createElement('div');
user.classList.add('user');
grid.appendChild(user);
drawUser();

//add ball
const ball = document.createElement('div');
ball.classList.add('ball');
grid.appendChild(ball);
drawBall();

//move user
function moveUser(e) {
  switch (e.key) {
    case 'ArrowLeft':
      if (currentPosition[0] > 0) {
        currentPosition[0] -= 15;
        drawUser();
      }
      break;
    case 'ArrowRight':
      if (currentPosition[0] < (boardWidth - blockWidth)) {
        currentPosition[0] += 15;
        drawUser();
      }
      break;
  }
}
document.addEventListener('keydown', moveUser)

//draw User
function drawUser() {
  user.style.left = currentPosition[0] + 'px';
  user.style.bottom = currentPosition[1] + 'px';
}

//draw Ball
function drawBall() {
  ball.style.left = ballCurrentPosition[0] + 'px';
  ball.style.bottom = ballCurrentPosition[1] + 'px';
}

//move ball
function moveBall() {
    ballCurrentPosition[0] += xDirection;
    ballCurrentPosition[1] += yDirection;
    drawBall();
    checkForCollisions();
}
timerId = setInterval(moveBall, 30);

//check for collisions
function checkForCollisions() {
  //check for block collision
//   for (let i = 0; i < 10; i++){
    if ((ballCurrentPosition[0] > 20 && ballCurrentPosition[0] < 1020) && ((ballCurrentPosition[1] + ballDiameter) > 708 && ballCurrentPosition[1] < 728))
    {
        const allBlocks = Array.from(document.querySelectorAll('.block'));
        allBlocks[i].classList.remove('block');
        allBlocks.splice(i, 1);
        changeDirection();
        score++;
        scoreDisplay.innerHTML = score;
        if (allBlocks.length == 0) {
            scoreDisplay.innerHTML = 'You Win!';
            clearInterval(timerId);
            document.removeEventListener('keydown', moveUser);
        }
    }
//   }
  // check for wall hits
  if (ballCurrentPosition[0] >= (boardWidth - ballDiameter) || ballCurrentPosition[0] <= 0 || ballCurrentPosition[1] >= (boardHeight - ballDiameter))
  {
    changeDirection();
  }

  //check for user collision
  if ((ballCurrentPosition[0] > currentPosition[0] && ballCurrentPosition[0] < currentPosition[0] + blockWidth) && (ballCurrentPosition[1] > currentPosition[1] && ballCurrentPosition[1] < currentPosition[1] + blockHeight ) 
  )
  {
    changeDirection();
  }

  //game over
  if (ballCurrentPosition[1] <= 0) {
    clearInterval(timerId);
    scoreDisplay.innerHTML = 'You lose!';
    document.removeEventListener('keydown', moveUser);
  }
}


function changeDirection() {
  if (xDirection === 4 && yDirection === 4) {
    yDirection = -4;
    return;
  }
  if (xDirection === 4 && yDirection === -4) {
    xDirection = -4;
    return;
  }
  if (xDirection === -4 && yDirection === -4) {
    yDirection = 4;
    return;
  }
  if (xDirection === -4 && yDirection === 4) {
    xDirection = 4;
    return;
  }
}
