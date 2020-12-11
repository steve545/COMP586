"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var authorwithbooks_service_1 = require("./authorwithbooks.service");
describe('AuthorwithbooksService', function () {
    var service;
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({});
        service = testing_1.TestBed.inject(authorwithbooks_service_1.AuthorwithbooksService);
    });
    it('should be created', function () {
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=authorwithbooks.service.spec.js.map