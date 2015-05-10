var MongoClient = require('mongodb').MongoClient;
var assert = require('assert');
// Connection URL
var url = 'mongodb://10.0.1.84:37017/reader';
var r = {};
var insertDocuments = function(outlines, db, callback) {
  // Get the documents collection
  var collection = db.collection('feeds');
  // Insert some documents
  collection.insert(outlines, function(err, result) {

    console.log(err);
    if (callback)
      callback(result);
    db.close();
  });
}
r.connect = function(callback) {
  MongoClient.connect(url, function(err, db) {
    if (callback) callback(err, db);
    else
      db.close();
  });
};
r.add = function(outlines, callback) {
  MongoClient.connect(url, function(err, db) {
    insertDocuments(outlines, db, callback)
    db.close();
  });
};
r.find=function(callback){
  MongoClient.connect(url, function(err, db) {
    var collection = db.collection('feeds');
    // Insert some documents
    collection.find({}, function(err, result) {
      console.log(err);
      console.log(result);
    });
    db.close();
  });
}
module.exports = r;
