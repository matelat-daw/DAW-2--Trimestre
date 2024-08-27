const grid = document.querySelector('.grid');
const scoreDisplay = document.querySelector('#score');
const blockWidth = 100;
const blockHeight = 20;
const ballDiameter = 20;
const boardWidth = 1024;
const boardHeight = 768;
let xDirection = -4;
let yDirection = 4;

const userStart = [230, 10]
let currentPosition = userStart

const ballStart = [270, 40]
let ballCurrentPosition = ballStart

let timerId
let score = 0

//my block
class Block {
    constructor(xAxis, yAxis) {
        this.bottomLeft = [xAxis, yAxis];
        this.bottomRight = [xAxis + blockWidth, yAxis];
        this.topRight = [xAxis + blockWidth, yAxis + blockHeight];
        this.topLeft = [xAxis, yAxis + blockHeight];
    }
}

//all my blocks
const blocks = [
    new Block(20, 720),
    new Block(130, 720),
    new Block(240, 720),
    new Block(350, 720),
    new Block(460, 720),
    new Block(570, 720),
    new Block(680, 720),
    new Block(790, 720),
    new Block(900, 720),
    new Block(20, 690),
    new Block(130, 690),
    new Block(240, 690),
    new Block(350, 690),
    new Block(460, 690),
    new Block(570, 690),
    new Block(680, 690),
    new Block(790, 690),
    new Block(900, 690),
    new Block(20, 660),
    new Block(130, 660),
    new Block(240, 660),
    new Block(350, 660),
    new Block(460, 660),
    new Block(570, 660),
    new Block(680, 660),
    new Block(790, 660),
    new Block(900, 660)
]

//draw my blocks
function addBlocks() {
    for (let i = 0; i < blocks.length; i++) {
        const block = document.createElement('div');
        block.classList.add('block');
        block.style.left = blocks[i].bottomLeft[0] + 'px';
        block.style.bottom = blocks[i].bottomLeft[1] + 'px';
        switch (i)
        {
            case 0:
            case 4:
            case 8:
            case 12:
            case 16:
            case 20:
            case 24:
                block.style.backgroundColor = 'red';
                break;
            case 1:
            case 5:
            case 9:
            case 13:
            case 17:
            case 21:
            case 25:
                block.style.backgroundColor = 'green';
                break;
            case 2:
            case 6:
            case 10:
            case 14:
            case 18:
            case 22:
            case 26:
                block.style.backgroundColor = 'blue';
                break;
            default:
                block.style.backgroundColor = 'yellow';
        }
        grid.appendChild(block);
    }
}
addBlocks()

//add user
const user = document.createElement('div')
user.classList.add('user')
grid.appendChild(user)
drawUser()

//add ball
const ball = document.createElement('div')
ball.classList.add('ball')
grid.appendChild(ball)
drawBall()

//move user
function moveUser(e) {
    switch (e.key) {
        case 'ArrowLeft':
            if (currentPosition[0] > 0) {
                currentPosition[0] -= 10
                // console.log(currentPosition[0] > 0)
                drawUser()
            }
            break
        case 'ArrowRight':
            if (currentPosition[0] < (boardWidth - blockWidth)) {
                currentPosition[0] += 10
                // console.log(currentPosition[0])
                drawUser()
            }
            break
    }
}
document.addEventListener('keydown', moveUser)

//draw User
function drawUser() {
    user.style.left = currentPosition[0] + 'px'
    user.style.bottom = currentPosition[1] + 'px'
}

//draw Ball
function drawBall() {
    ball.style.left = ballCurrentPosition[0] + 'px'
    ball.style.bottom = ballCurrentPosition[1] + 'px'
}

//move ball
function moveBall() {
    ballCurrentPosition[0] += xDirection
    ballCurrentPosition[1] += yDirection
    drawBall()
    checkForCollisions()
}
timerId = setInterval(moveBall, 30)

//check for collisions
function checkForCollisions() {
    //check for block collision
    for (let i = 0; i < blocks.length; i++) {
        if ((ballCurrentPosition[0] > blocks[i].bottomLeft[0] && ballCurrentPosition[0] < blocks[i].bottomRight[0]) && ((ballCurrentPosition[1] + ballDiameter) > blocks[i].bottomLeft[1] && ballCurrentPosition[1] < blocks[i].topLeft[1])) {
            const allBlocks = Array.from(document.querySelectorAll('.block'))
            allBlocks[i].classList.remove('block')
            blocks.splice(i, 1)
            changeDirection()
            score++
            scoreDisplay.innerHTML = score;
            if (blocks.length == 0) {
                scoreDisplay.innerHTML = 'You Win! You made: ' + score;
                clearInterval(timerId);
                document.removeEventListener('keydown', moveUser);
            }
        }
    }
    // check for wall hits
    if (ballCurrentPosition[0] >= (boardWidth - ballDiameter) || ballCurrentPosition[0] <= 0 || ballCurrentPosition[1] >= (boardHeight - ballDiameter)) {
        changeDirection()
    }

    //check for user collision
    if ((ballCurrentPosition[0] > currentPosition[0] && ballCurrentPosition[0] < currentPosition[0] + blockWidth) && (ballCurrentPosition[1] > currentPosition[1] && ballCurrentPosition[1] < currentPosition[1] + blockHeight)) {
        changeDirection()
    }

    //game over
    if (ballCurrentPosition[1] <= 0) {
        clearInterval(timerId)
        scoreDisplay.innerHTML = 'You lose!'
        document.removeEventListener('keydown', moveUser)
    }
}


function changeDirection() {
    if (xDirection === 4 && yDirection === 4) {
        yDirection = -4
        return
    }
    if (xDirection === 4 && yDirection === -4) {
        xDirection = -4
        return
    }
    if (xDirection === -4 && yDirection === -4) {
        yDirection = 4
        return
    }
    if (xDirection === -4 && yDirection === 4) {
        xDirection = 4
        return
    }
}