const wandA = {Description: "Wand of Yew, core of phoenix tail feather, 10 and three quarters inches", ImageUrl: ""}
const wandB = {Description: "Wand of Dogwood, core of dragon heart string, 12 inches", ImageUrl: ""}
const wandC = {Description: "Wand of Maple, core of unicorn hair, 9 and half inches", ImageUrl: ""}
const wandD = {Description: "Wand of Mahogany, core of basilisk horn, 11 inches", ImageUrl: ""}

$("#wand-quiz").submit(function (event) {
  event.preventDefault();
  let a = 0;
  let b = 0;
  let c = 0;
  let d = 0;

  $("#wandInput:checked").each(function () {
    switch ($(this).val()) {
      case "a":
        a++;
        break;
      case "b":
        b++;
        break;
      case "c":
        c++;
        break;
      case "d":
        d++;
        break;
    }
  });
  // let results = { "a": a, "b": b, "c": c, "d": d };
  let results = { a, b, c, d };
  const maxVal = Math.max(...Object.values(results));
  const key = Object.keys(results).find((key) => results[key] === maxVal);

  let wand = {Description: "", Url: ""}
  switch (key) {
    case "a":
      wand.Description = wandA.Description;
      wand.Url = wandA.Url;
      break;
    case "b":
      wand.Description = wandB.Description;
      wand.Url = wandB.Url;
    break;
    case "c":
      wand.Description = wandC.Description;
      wand.Url = wandC.Url;
    break;
    case "d":
      wand.Description = wandD.Description;
      wand.Url = wandD.Url;
    break;
  }
  $.ajax({
    type: "POST",
    url: "../../Students/BuyWand",
    data: { StudentId: /* we need to grab the student id here some how */ 1, Description: wand.Description, ImageUrl: wand.ImageUrl },
    success: function (result) {
      $("#wand-description").text(result.wand.description);
      $("#wand-url").text(result.wand.imageUrl);
      $("#wand-result").removeClass("hide");
      $("#wand-quiz").addClass("hide");
    },
    error: function () {
      alert(`Error while fetching patrons`);
    },
  });
});