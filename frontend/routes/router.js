var express = require('express');
var router = express.Router();

const indexController = require('../controller/indexController');

// GET REQUESTS
router.get('/', indexController.indexView);
router.get('/pass', indexController.passView);


// POST REQUESTS

router.post('/calculate', indexController.calculatePost);


module.exports = router;
