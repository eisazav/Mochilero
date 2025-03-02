const controller = {};
const _ = require('underscore');
const service = require('../engine/apiService.js');
const helpers = require('../engine/helpers.js');

controller.indexView = async (req, res, next) => {
  res.render('index');
}

controller.passView = async (req, res, next) => {
    res.render('hikerResult',{"data":req.query.data});
  }

controller.calculatePost = async(req, res, next) => {
  const calculateParams = {
    "name": req.body.name,
    "weight": parseInt(req.body.weight),
    "calories": parseInt(req.body.calories)
  }
  
  let resp = await service.calculate(calculateParams);
  console.log(resp);
  if (resp.data) {
    console.log("----------------------------------------data----------------------------------------\n");
    console.log(resp.data);
    return res.send({'success': true, 'data': resp.data});
  }
  console.log("error3");
  return res.send({'err': 'error'});
}
  


module.exports = controller;