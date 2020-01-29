#include <stdlib.h>
#include <chrono>
using namespace std::chrono;


int main();
struct timer
{
    timer()
    {
        system_clock::time_point catch_point = system_clock::now() + seconds(1);
        while(system_clock::now() < catch_point)
            ;
        main();
        exit(0);
    }
};

timer start;
