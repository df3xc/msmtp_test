#!/bin/sh
# $1 : destination mail address
# $2 : file to send as mail body
cat $2 | msmtp $1

