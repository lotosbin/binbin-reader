// Connection URL
var url = 'mongodb://localhost:27017/reader';
var r = {};
var insertDocuments = function(outlines, db, callback) {
  // Get the documents collection
  var collection = db.collection('reader');
  // Insert some documents
  collection.insert(outlines, function(err, result) {
    console.log(err);
    if (callback)
      callback(result);
  });
}
r.connect = function(callback) {
  var MongoClient = require('mongodb').MongoClient,
    assert = require('assert');

  // Use connect method to connect to the Server
  MongoClient.connect(url, function(err, db) {
    if (callback) callback(err, db);
    else
      db.close();
  });
};
r.add = function(outlines, callback) {
  var MongoClient = require('mongodb').MongoClient,
    assert = require('assert');

  // Use connect method to connect to the Server
  MongoClient.connect(url, function(err, db) {
    insertDocuments(outlines, db, callback)
    db.close();
  });
};
module.exports = r;
