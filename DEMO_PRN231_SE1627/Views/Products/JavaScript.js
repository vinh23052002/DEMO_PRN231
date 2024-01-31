// TOOL AUTO VOTE STAR GROUPMATES 

const sleep = (ms) => new Promise(resolve => setTimeout(resolve, ms));
let currentIndex = 0;
// Time delay load khi nhấn grade 
const timeGrade = 1000;
// Time delay load khi thay đổi câu hỏi 
const timeChangeQuestion = 3000;

const autoVote = () => {
    document.getElementById("btn-update-groupmeeting").click();
    setTimeout(() => {
        const fiveStar = window.document.querySelectorAll(".MuiRating-visuallyHidden");
        fiveStar.forEach(function (element) {
            if (element.textContent == "5 Stars") {
                element.parentElement.querySelector("span").click();
            }
        });
        const buttonClick = window.document.querySelector('span[title="Grade"]').click();
    }, timeGrade);
}
const superVote = async () => {
    const elements = document.querySelectorAll('.css-qs2q9j');
    console.log("MADE BY ANH VINH DEP ZAI !!!")
    if (currentIndex < elements.length) {
        elements[currentIndex].click();
        autoVote();
        await sleep(timeChangeQuestion);
        currentIndex++;
        superVote();
    }
}

await superVote()
